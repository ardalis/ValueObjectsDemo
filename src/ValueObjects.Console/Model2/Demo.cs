namespace ValueObjects.ConsoleDemo.Model2;

public static class Model2Demo
{
    public static void DemoModelUsage()
    {
        Console.WriteLine("Model 2 - Basic Value Objects");

        var worker = new Worker(new Name("Jane", "Doe"),
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