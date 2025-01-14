using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ValueObjects.ConsoleDemo.Model1;
using ValueObjects.ConsoleDemo.Model2;
using ValueObjects.ConsoleDemo.Model3;
using Vogen;

namespace ValueObjects.ConsoleDemo;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Worker> Workers => Set<Worker>();

    public DbSet<Laborer> Laborers => Set<Laborer>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VODemo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Worker>()
            .OwnsOne(w => w.Name);
        modelBuilder.Entity<Worker>()
            .OwnsOne(w => w.Address);
        modelBuilder.Entity<Worker>()
            .OwnsOne(w => w.EmploymentDates);

        // model 3
        modelBuilder.Entity<Laborer>(b =>
        {
            b.HasKey(x => x.Id);

            b.Property(l => l.Id)
            .HasValueGenerator<LaborerIdValueGenerator>()
            .HasVogenConversion()
            .IsRequired();
        });
        modelBuilder.Entity<Laborer>()
            .OwnsOne(w => w.Name);
        modelBuilder.Entity<Laborer>()
            .OwnsOne(w => w.Address);
        modelBuilder.Entity<Laborer>()
            .OwnsOne(w => w.EmploymentDates);

    }
}

[EfCoreConverter<LaborerId>]
internal partial class VogenEfCoreConverters;

internal class LaborerIdValueGenerator : ValueGenerator<LaborerId>
{
    public override LaborerId Next(EntityEntry entry)
    {
        var entities = ((AppDbContext)entry.Context).Laborers;

        var next = Math.Max(
            maxFrom(entities.Local),
            maxFrom(entities)) + 1;

        return LaborerId.From(next);

        static int maxFrom(IEnumerable<Laborer> es)
        {
            return es.Any() ? es.Max(e => e.Id.Value) : 0;
        }
    }

    public override bool GeneratesTemporaryValues => false;
}