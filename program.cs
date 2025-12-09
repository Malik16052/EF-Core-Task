using EfCoreExample.Data;
using EfCoreExample.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        using var db = new AppDbContext();

        // 1. Add data
        AddSampleData(db);

        // 2. Get All
        GetAllCars(db);

        // 3. Get By Id
        GetCarById(db, 1);

        // 4. Delete
        DeleteCar(db, 1);

        Console.ReadKey();
    }

    static void AddSampleData(AppDbContext db)
    {
        var model = new Model { Name = "BMW X Series" };
        var car = new Car
        {
            Brand = "BMW",
            Price = 45000,
            Year = 2022,
            Model = model
        };

        db.Models.Add(model);
        db.Cars.Add(car);
        db.SaveChanges();

        Console.WriteLine("Data added.");
    }

    static void GetAllCars(AppDbContext db)
    {
        var cars = db.Cars.Include(c => c.Model).ToList();

        foreach (var car in cars)
        {
            Console.WriteLine($"Id: {car.Id}, Brand: {car.Brand}, Model: {car.Model.Name}, Price: {car.Price}");
        }
    }

    static void GetCarById(AppDbContext db, int id)
    {
        var car = db.Cars.Include(c => c.Model).FirstOrDefault(c => c.Id == id);

        if (car == null)
            Console.WriteLine("Car not found.");
        else
            Console.WriteLine($"Found -> {car.Brand} {car.Model.Name}");
    }

    static void DeleteCar(AppDbContext db, int id)
    {
        var car = db.Cars.Find(id);

        if (car == null)
        {
            Console.WriteLine("Not found.");
            return;
        }

        db.Cars.Remove(car);
        db.SaveChanges();
        Console.WriteLine("Car deleted.");
    }
}
