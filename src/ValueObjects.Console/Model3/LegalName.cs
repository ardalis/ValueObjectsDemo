using Vogen;

namespace ValueObjects.ConsoleDemo.Model3;

[ValueObject<string>]
public partial class LegalName
{
    private static Validation Validate(in string name) => String.IsNullOrEmpty(name) ?
      Validation.Invalid("Name cannot be empty") :
      Validation.Ok;

    private static string NormalizeInput(string input) => input.Trim();
}