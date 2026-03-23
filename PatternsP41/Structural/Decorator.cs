using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;


public class DecoratorExampleClientCode
{
    public void Run()
    {
        // logging => validation => base component

        var loggingEnabled = false;
        var validationEnabled = false;

        IComponent component = new SomeComponent();
        
        if (validationEnabled)
        {
            component = new ValidationDecorator(component);
        }
        if (loggingEnabled)
        {
            component = new LoggingDecorator(component);
        }

        component.Operation("Some data");

        

    }
}

public interface IComponent
{
    void Operation(string data);
}


class LoggingDecorator : IComponent
{
    private readonly string _fileName;
    private readonly IComponent _component;
    public LoggingDecorator(IComponent component, string fileName = "log.txt")
    {
        _component = component;
        _fileName = fileName;
    }
    public void Operation(string data)
    {
        // Логування даних перед виконанням операції
        Console.WriteLine($"LoggingDecorator: Operation called with data: {data} at {DateTime.Now}");
        File.WriteAllText(_fileName, $"LoggingDecorator: Operation called with data: {data} at {DateTime.Now}");
        // Виклик операції базового компонента
        _component.Operation(data);
    }
}

public class ValidationDecorator : IComponent
{
    private readonly IComponent _component;
    public ValidationDecorator(IComponent component)
    {
        _component = component;
    }
    public void Operation(string data)
    {
        Console.WriteLine($"ValidationDecorator: Operation called with data: {data} at {DateTime.Now}");    
        // Додавання перевірки даних перед виконанням операції
        if (data == "invalid data")
        {
            Console.WriteLine("ValidationDecorator: Data is invalid. Operation aborted.");
            return;
        }
        // Виклик операції базового компонента
        _component.Operation(data);
    }
}



public class SomeComponent: IComponent
{
    public virtual void Operation(string data)
    {
        Console.WriteLine("Base component operation with data: " + data);
    }
}




