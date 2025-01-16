using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ValueObjects.ConsoleDemo.Model3;

public class LaborerConfiguration : IEntityTypeConfiguration<Laborer>
{
    public void Configure(EntityTypeBuilder<Laborer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(l => l.Id)
            .HasValueGenerator<LaborerIdValueGenerator>()
            .HasVogenConversion()
            .IsRequired();

        builder.OwnsOne(x => x.Name, b =>
        {
            b.Property(l => l.FirstName)
                .HasVogenConversion()
                .IsRequired();

            b.Property(l => l.LastName)
                .HasVogenConversion()
                .IsRequired();
        });
        builder.OwnsOne(w => w.Address);
        builder.OwnsOne(w => w.EmploymentDates);
    }
}
