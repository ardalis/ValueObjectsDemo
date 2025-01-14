namespace ValueObjects.ConsoleDemo.Model1;

public static class Model1Demo
{
    public static void DemoModelUsage()
    {
        Console.WriteLine("Model 1 - Primitive Obsession...");

        var employee = new Employee("John",
                                     "Doe",
                                     DateTime.Today.AddYears(-1),
                                     "123 Main St.",
                                     "Anytown",
                                     "OH",
                                     "12345",
                                     "USA");

        Console.WriteLine("Employee:");
        Console.WriteLine(employee);

        using (var db = new AppDbContext())
        {
            db.Add(employee);
            db.SaveChanges();
            Console.WriteLine($"{employee.GetType()} saved.");

        }

        Console.WriteLine();
        Console.WriteLine();
    }
}