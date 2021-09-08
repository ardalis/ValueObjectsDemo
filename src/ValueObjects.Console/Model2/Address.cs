using CSharpFunctionalExtensions;

namespace ValueObjects.Console.Model2;

public class Address : ValueObject
{
    public string Address1 { get; private set; }
    public string? Address2 { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string PostalCode { get; private set; }
    public string Country { get; private set; }

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

