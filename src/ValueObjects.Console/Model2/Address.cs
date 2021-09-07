using CSharpFunctionalExtensions;

namespace ValueObjects.Console.Model2;

public class Address : ValueObject
{
    public Address(string address1, string city, string state,
        string postalCode, string country, string? address2 = null)
    {
        Address1 = address1;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        Address2 = address2;
    }

    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"{Address1}\n{Address2}\n{City}, {State} {PostalCode}\n{Country}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address1;
        yield return Address2 ?? "";
        yield return City;
        yield return State;
        yield return PostalCode;
        yield return Country;
    }
}

