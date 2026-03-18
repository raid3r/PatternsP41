using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Creational;


class BuilderExampleClientCode
{
    public void Run()
    {

        //var car1 = new CarBuilder()
        //    .Init()
        //    .Set4Wheels()
        //    .SetColor("Red")
        //    .SetEngine("V8", "Gasoline")
        //    .SetName("Mustang")
        //    .AddFeature("Sunroof")
        //    .AddFeature("Leather Seats")
        //    .AddFeature("Bluetooth")
        //    .Build();


        //var car2 = new CarBuilder()
        //    .Init()
        //    .Set4Wheels()
        //    .SetColor("Blue")
        //    .SetEngine("V6", "Diesel")
        //    .SetName("Camaro")
        //    .AddFeature("Sport Package")
        //    .AddFeature("Navigation System")
        //    .Build();

        var director = new CarDirector(new CarBuilder());

        var car1 = director.BuildSportsCar();
        var car2 = director.BuildFamilyCar();

        Console.WriteLine(car1);
        Console.WriteLine(car2);
       
        //var car1 = new Car();
        //car1.Wheels = 4;
        //car1.Color = "Red";
        //car1.EngineType = "V8";
        //car1.PetrolType = "Gasoline";
        //car1.Name = "Mustang";
        //car1.AdditionalFeatures.AddRange(new[] { "Sunroof", "Leather Seats", "Bluetooth" });

        //Console.WriteLine(car1);

        //var car2 = new Car();
        //car2.Wheels = 4;
        //car2.Color = "Blue";
        //car2.EngineType = "V6";
        //car2.Name = "Camaro";
        //car2.PetrolType = "Diesel";
        //car2.AdditionalFeatures.AddRange(new[] { "Sport Package", "Navigation System" });
        //Console.WriteLine(car2);


    }
}

public class CarBuilder
{
    private Car _car = new Car();

    public CarBuilder Init()
    {
        _car = new Car();
        return this;
    }

    public CarBuilder Set4Wheels()
    {
        _car.Wheels = 4;
        return this;
    }

    public CarBuilder SetWheels(int wheels)
    {
        if (wheels < 0)
            throw new ArgumentException("Wheels cannot be negative.");
        _car.Wheels = wheels;
        return this;
    }

    public CarBuilder SetColor(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Color cannot be empty.");
        _car.Color = color;
        return this;
    }

    public CarBuilder SetEngine(string engineType, string petrolType)
    {
        string[] validEngineTypes = { "V6", "V8", "Electric", "Hybrid" };
        string[] validPetrolTypes = { "Gasoline", "Diesel", "Electric", "Hybrid" };

        if (!validEngineTypes.Contains(engineType))
            throw new ArgumentException($"Invalid engine type. Valid options are: {string.Join(", ", validEngineTypes)}");

        if (!validPetrolTypes.Contains(petrolType))
            throw new ArgumentException($"Invalid petrol type. Valid options are: {string.Join(", ", validPetrolTypes)}");

        _car.EngineType = engineType;
        _car.PetrolType = petrolType;
        return this;

    }


    public CarBuilder SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
        _car.Name = name;
        return this;
    }

    public CarBuilder AddFeature(string feature)
    {
        if (string.IsNullOrWhiteSpace(feature))
            throw new ArgumentException("Feature cannot be empty.");
        _car.AdditionalFeatures.Add(feature);
        return this;
    }

    public Car Build()
    {
        if (_car.Wheels <= 0)
            throw new InvalidOperationException("Car must have at least one wheel.");
        if (string.IsNullOrWhiteSpace(_car.Color))
            throw new InvalidOperationException("Car must have a color.");
        if (string.IsNullOrWhiteSpace(_car.EngineType))
            throw new InvalidOperationException("Car must have an engine type.");
        if (string.IsNullOrWhiteSpace(_car.PetrolType))
            throw new InvalidOperationException("Car must have a petrol type.");
        if (string.IsNullOrWhiteSpace(_car.Name))
            throw new InvalidOperationException("Car must have a name.");
        return _car;
    }

}


public class Car
{
    public int Wheels { get; set; }
    public string Color { get; set; }
    public string EngineType { get; set; }
    public string PetrolType { get; set; }
    public string Name { get; set; }
    public List<string> AdditionalFeatures { get; set; } = new List<string>();

    public override string ToString()
    {
        return $"Car: {Name}, Wheels: {Wheels}, Color: {Color}, Engine: {EngineType}, Petrol: {PetrolType}, Additional Features: {string.Join(", ", AdditionalFeatures)}";
    }
}


public class CarDirector
{
    private CarBuilder _builder;
    public CarDirector(CarBuilder builder)
    {
        _builder = builder;
    }
    public Car BuildSportsCar()
    {
        var builder = new CarBuilder();
        string engineType = "V8";
        if (engineType == "V8")
        {
            builder.SetEngine("V8", "Gasoline");
        } else if (engineType == "Electric")
        {
            builder.SetEngine("Electric", "Electric");
        }

        return builder
                .Set4Wheels()
                .SetColor("Red")
                .SetName("Mustang")
                .AddFeature("Sunroof")
                .AddFeature("Leather Seats")
                .AddFeature("Bluetooth")
                .Build();
    }
    public Car BuildFamilyCar()
    {
        return _builder.Init()
            .Set4Wheels()
            .SetColor("Blue")
            .SetEngine("V6", "Diesel")
            .SetName("Camaro")
            .AddFeature("Sport Package")
            .AddFeature("Navigation System")
            .Build();
    }
}
