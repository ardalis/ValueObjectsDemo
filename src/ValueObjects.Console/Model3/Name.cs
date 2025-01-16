using CSharpFunctionalExtensions;

namespace ValueObjects.ConsoleDemo.Model3;

public class Name(LegalName firstName, LegalName lastName) : ValueObject
{
    public LegalName FirstName { get; private set; } = firstName;
    public LegalName LastName { get; private set; } = lastName;

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

