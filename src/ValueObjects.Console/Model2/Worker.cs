namespace ValueObjects.Console.Model2;

public class Worker : BaseEntity
{
    public Worker(Name name, DateTimeRange employmentDates, Address address)
    {
        Name = name;
        EmploymentDates = employmentDates;
        Address = address;
    }

    private Worker() { } // EF

    public Name Name { get; set; }
    public DateTimeRange EmploymentDates { get; set; }
    public Address Address { get; set; }

    public override string ToString()
    {
        return $"{Name}\n{EmploymentDates}\n{Address}";
    }
}

