using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace ValueObjects.ConsoleDemo.Model2;

public class Name : ValueObject
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public Name(string firstName, string lastName)
    {
        FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
    }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return FirstName;
        yield return LastName;
    }
}

