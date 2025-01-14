namespace ValueObjects.ConsoleDemo.Model1;

public class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public Employee(string firstName,
                    string lastName,
                    DateTime startDate,
                    string address1,
                    string city,
                    string state,
                    string postalCode,
                    string country,
                    string? address2 = null)
    {
        FirstName = firstName;
        LastName = lastName;
        StartDate = startDate;
        Address1 = address1;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        Address2 = address2;
    }

    public override string ToString()
    {
        string name = $"{FirstName} {LastName}";
        string dates = $"{StartDate.ToShortDateString()}-{EndDate?.ToShortDateString()}";
        string address = $"{Address1}\n{Address2}\n{City}, {State} {PostalCode}\n{Country}";
        return $"{name}\n{dates}\n{address}";
    }
}
