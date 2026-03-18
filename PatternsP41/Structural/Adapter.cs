using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;

public class AdapterExampleClientCode
{
    public void Run()
    {

        //var myElectricEngine = new MyElectricEngine();
        //myElectricEngine.Start();
        //myElectricEngine.Stop();
        //myElectricEngine.PowerOn();
        //myElectricEngine.Start();

        var electricEngine = new ElectricEngine();
        var electricEngineAdapter = new ElectricEngineAdapter(electricEngine);
        var electricCar = new Car(electricEngineAdapter);
        electricCar.Drive();

        var petrolEngine = new PetrolEngine();
        var petrolCar = new Car(petrolEngine);
        petrolCar.Drive();

    }
}


public class ElectricEngine
{
    public void PowerOn()
    {
        Console.WriteLine("Electric engine powered on.");
    }
    public void PowerOff()
    {
        Console.WriteLine("Electric engine powered off.");
    }
}

public class MyElectricEngine : ElectricEngine, IEngine
{
    public void Start()
    {
        PowerOn();
    }

    public void Stop()
    {
        PowerOff();
    }
}

public class ElectricEngineAdapter : IEngine
{
    private readonly ElectricEngine _electricEngine;
    public ElectricEngineAdapter(ElectricEngine electricEngine)
    {
        _electricEngine = electricEngine;
    }
    public void Start()
    {
        _electricEngine.PowerOn();
    }
    public void Stop()
    {
        _electricEngine.PowerOff();
    }
}





public class PetrolEngine : IEngine
{
    public void Start()
    {
        Console.WriteLine("Petrol engine started.");
    }

    public void Stop() { 
        Console.WriteLine("Petrol engine stopped.");
    } 
}


public interface IEngine
{
    void Start();
    void Stop();
}

public class Car
{
    public Car(IEngine engine)
    {
        Engine = engine;
    }

    public IEngine Engine { get; private set; }


    public void Drive()
    {
        Engine.Start();
        Console.WriteLine("Car is driving...");
        Engine.Stop();
    }

}



