namespace ValueObjects.ConsoleDemo.Model2;

public class Worker : BaseEntity
{
    public Name Name { get; set; }
    public DateTimeRange EmploymentDates { get; set; }
    public Address Address { get; set; }

    public Worker(Name name, DateTimeRange employmentDates, Address address)
    {
        Name = name;
        EmploymentDates = employmentDates;
        Address = address;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Worker() { } // EF
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public override string ToString()
    {
        return $"{Name}\n{EmploymentDates}\n{Address}";
    }
}
