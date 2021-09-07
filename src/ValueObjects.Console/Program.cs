// See https://aka.ms/new-console-template for more information
using ValueObjects.Console.Model1;
using ValueObjects.Console.Model2;

Console.WriteLine("Hello, World!");

var employee = new  Employee("John", "Doe", DateTime.Today.AddYears(-1), "123 Main St.", "Anytown", "OH", "12345", "USA");

var worker = new Worker(new Name("Jane", "Doe"),
        new DateTimeRange(DateTime.Today.AddYears(-1), null),
        new Address("123 Main St.", "Anytown", "OH", "12345", "USA"));

Console.WriteLine("Employee:");
Console.WriteLine(employee);
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Worker:");
Console.WriteLine(worker);

using (var db = new AppDbContext())
{
    db.Add(employee);
    db.Add(worker);
    db.SaveChanges();
}

Console.WriteLine("All data saved.");
