using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ValueObjects.ConsoleDemo.Model2;

public class WorkerConfiguration : IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.OwnsOne(w => w.Name);
        builder.OwnsOne(w => w.Address);
        builder.OwnsOne(w => w.EmploymentDates);
    }
}
