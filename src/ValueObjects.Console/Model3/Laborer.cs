namespace ValueObjects.ConsoleDemo.Model3;

public class Laborer
{
    public LaborerId Id { get; set; } = null!; // must be null for EF Core to generate a value
    public Name Name { get; set; }
    public DateTimeRange EmploymentDates { get; set; }
    public Address Address { get; set; }

    public Laborer(Name name, DateTimeRange employmentDates, Address address)
    {
        Name = name;
        EmploymentDates = employmentDates;
        Address = address;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Laborer() { } // EF
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public override string ToString()
    {
        return $"{Name}\n{EmploymentDates}\n{Address}";
    }
}
