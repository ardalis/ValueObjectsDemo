namespace ValueObjects.ConsoleDemo.Model3;

public static class Model3Demo
{
    public static void DemoModelUsage()
    {
        Console.WriteLine("Model 3 - Better Value Objects");

        var worker = new Laborer(new Name("Jane", "Doe"),
                                new DateTimeRange(DateTime.Today.AddYears(-1), null),
                                new Address("123 Main St.", "Anytown", "OH", "12345", "USA"));

        Console.WriteLine("Worker:");
        Console.WriteLine(worker);

        using (var db = new AppDbContext())
        {
            db.Add(worker);
            db.SaveChanges();
            Console.WriteLine($"{worker.GetType()} saved.");
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}