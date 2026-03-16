// See https://aka.ms/new-console-template for more information
using PatternsP41.Creational;

Console.WriteLine("Hello, World!");




/*
 UML - Unified Modeling Language

- для візуалізації, 
- опису, 
- конструювання 
- документування 

Види діаграм UML:

- Діаграми класів (Class Diagram)
- Діаграма варіантів використання (Use Case Diagram)
- Діаграма активностей (Activity Diagram)
- Діаграма послідовності (Sequence Diagram)

- Діаграма станів (State Diagram)

Чернетка - Нове замовлення - Офрмлено - Оплачено - Відправлено - Доставлено
                                      - Відмінено

- Діаграма компонентів (Component Diagram)
- Діаграма розгортання (Deployment Diagram)
- Діаграма пакетів (Package Diagram)

*/

/*
Патерни проектування (Design Patterns) - 
це повторювані рішення для загальних проблем, що виникають під час розробки програмного забезпечення. Вони надають шаблони для організації коду та взаємодії між об'єктами. 

Види патернів проектування:
- Породжуючі (Creational) - зосереджені на створенні об'єктів.
- Структурні (Structural) - зосереджені на організації класів та об'єктів.
- Поведінкові (Behavioral) - зосереджені на взаємодії між об'єктами та їх поведінці.


 - Породжуючі (Creational)
- Одиночка (Singleton)
- Фабричний метод (Factory Method)  
- Абстрактна фабрика (Abstract Factory)
- Будівельник (Builder)
- Прототип (Prototype)

 */

void SomeMethod()
{
    var singleton2 = SingletonService.Instance;
    Console.WriteLine(singleton2.CreatedAt);
}



//var singleton1 = SingletonService.Instance;
//Console.WriteLine(singleton1.CreatedAt);
//Thread.Sleep(2000);
//SomeMethod();

Console.WriteLine("Press any key to exit...");
