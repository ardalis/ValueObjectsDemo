using Microsoft.EntityFrameworkCore;
using ValueObjects.Console.Model1;
using ValueObjects.Console.Model2;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Worker> Workers => Set<Worker>();

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
    }
}