using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;


public class FacadeExampleClientCode
{
    public void Method1()
    {
        Facade.DoSomething();
    }

    public void Method2()
    {

        Facade.DoSomething();
    }

    public IFacade Facade { get; set; }

    public IFacade Create()
    {
        var useLibraryA = true;
        if (useLibraryA)
        {
            return new Facade();
        }
        else
        {
            return new AnotherFacade();
        }
    }

    public void Run()
    {
        Facade = Create();
        Facade.DoSomething();

        Method1();
        Method2();
    }
}



public interface IFacade
{
    void DoSomething();
}

class Facade : IFacade
{
    private ComplexLibrary _library;
    public Facade()
    {
        _library = new ComplexLibrary();
    }
    public void DoSomething()
    {
        _library.OperationA();
        _library.OperationC();
        _library.OperationB();
        _library.OperationC();
    }
}


class AnotherFacade : IFacade
{
    private AnotherComplexLibrary _library;
    public AnotherFacade()
    {
        _library = new AnotherComplexLibrary();
    }
    public void DoSomething()
    {
        _library.OperationX();
        _library.OperationZ();
        _library.OperationY();
        _library.OperationZ();
    }
}


class ComplexLibrary
{
    public void OperationA()
    {
        Console.WriteLine("ComplexLibrary: Operation A");
    }
    public void OperationB()
    {
        Console.WriteLine("ComplexLibrary: Operation B");
    }
    public void OperationC()
    {
        Console.WriteLine("ComplexLibrary: Operation C");
    }
}

class AnotherComplexLibrary
{
    public void OperationX()
    {
        Console.WriteLine("AnotherComplexLibrary: Operation X");
    }
    public void OperationY()
    {
        Console.WriteLine("AnotherComplexLibrary: Operation Y");
    }
    public void OperationZ()
    {
        Console.WriteLine("AnotherComplexLibrary: Operation Z");
    }
}