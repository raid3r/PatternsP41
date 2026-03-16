using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Creational;

public class  SingletonService
{
    // Приватний конструктор,
    // щоб запобігти створенню об'єктів ззовні класу
    private SingletonService() {
        _createdAt = DateTime.Now;
        Console.WriteLine($"SingletonService created at {_createdAt}");
        
    }

    static SingletonService()
    {
        // Статичний конструктор, який ініціалізує єдиний екземпляр класу
        _instance = new SingletonService();
    }

    private DateTime _createdAt;

    private static SingletonService _instance;

    public static SingletonService Instance => _instance ??= new SingletonService();

    public DateTime CreatedAt => _createdAt;
}
