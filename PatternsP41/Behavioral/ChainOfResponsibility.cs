using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Behavioral;

public class ChainOfResponsibilityClientCode
{
    public IRequestHandler GetChain()
    {
        var handlerChain =
            new LoggingHandler()
            .SetNext(new AuthenticationHandler())
            .SetNext(new AuthorizationHandler())
            .SetNext(new AccessHandler());

        if (true)
        {
            handlerChain.SetNext(new EmptyDataValidationHandler());
            handlerChain.SetNext(new ForbiddenCharsValidationHandler());
        }
        else
        {

        }

        handlerChain
            .SetNext(new ProcessingHandler())
            .SetNext(new NotifyAfterProcessHandler());

        return handlerChain;
    }


    public void Run()
    {
        var handlerChain = GetChain();

        List<Request> requests = new List<Request>
        {
            new Request { User = "John", Password = "password123", Data = "Some data" },
            new Request { User = "Jane", Password = "password456", Data = "" },
            new Request { User = "Doe", Password = "password789", Data = "Data with @ forbidden character" },
            new Request { User = "Unknown", Password = "password000", Data = "Some data" }
        };

        foreach (var item in requests)
        {
            try
            {
                handlerChain.Handle(item);
            } catch (Exception ex)
            {
                Console.WriteLine($"Error processing request for user {item.User}: {ex.Message}");
            }

            Console.WriteLine("--------------------------------------------------");
        }






        // Записати запит у файл - логування
        // Перевірити що користувач з таким іменем існує
        // Перевірити що пароль правильний
        // Перевірити що користувач має доступ до даних
        // Перевірити що дані не порожні
        // Перевірити що дані не містять заборонених символів
        // Якщо всі перевірки пройшли, обробити запит та вивести результат


        // Запит -> Логування -> Аутентифікація -> Авторизація -> Валідація -> Обробка -> Логування


    }
}


public interface IRequestHandler
{
    void Handle(Request request);
    IRequestHandler SetNext(IRequestHandler handler);
}

public abstract class RequestHandlerBase : IRequestHandler
{
    private IRequestHandler _nextHandler;
    public virtual void Handle(Request request)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(request);
        }
    }
    public IRequestHandler SetNext(IRequestHandler handler)
    {
        if (_nextHandler == null)
        {
            _nextHandler = handler;
        }
        else
        {
            _nextHandler.SetNext(handler);
        }
        return this;
    }
}

// Записати запит у файл - логування
public class LoggingHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        File.AppendAllLines("requests.log", new[] { $"User: {request.User}, Data: {request.Data}" });
        Console.WriteLine($"Logging request for user: {request.User}");

        base.Handle(request);
    }
}

// Перевірити що користувач з таким іменем існує
public class AuthenticationHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Authenticating user: {request.User}");
        // Логіка перевірки існування користувача

        var validUsers = new List<string> { "John", "Jane", "Doe" };
        if (!validUsers.Contains(request.User))
        {
            Console.WriteLine($"User {request.User} does not exist.");
            return; // Зупинити обробку, якщо користувач не існує
        }

        base.Handle(request);
    }
}


// Перевірити що пароль правильний
public class AuthorizationHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Authorizing user: {request.User}");
        // Логіка перевірки правильності пароля
        var validPasswords = new Dictionary<string, string>
        {
            { "John", "password123" },
            { "Jane", "password456" },
            { "Doe", "password789" }
        };
        if (!validPasswords.ContainsKey(request.User) || validPasswords[request.User] != request.Password)
        {
            Console.WriteLine($"Invalid password for user {request.User}.");
            return; // Зупинити обробку, якщо пароль неправильний
        }
        base.Handle(request);
    }
}
// Перевірити що користувач має доступ до даних
public class AccessHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Checking access for user: {request.User}");
        // Логіка перевірки доступу до даних
        var userAccess = new Dictionary<string, bool>
        {
            { "John", true },
            { "Jane", false },
            { "Doe", true }
        };
        if (!userAccess.ContainsKey(request.User) || !userAccess[request.User])
        {
            Console.WriteLine($"User {request.User} does not have access to the data.");
            return; // Зупинити обробку, якщо користувач не має доступу
        }
        base.Handle(request);
    }
}
// Перевірити що дані не порожні
public class EmptyDataValidationHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Validating data for user: {request.User}");
        // Логіка перевірки що дані не порожні
        if (string.IsNullOrWhiteSpace(request.Data))
        {
            Console.WriteLine("Data cannot be empty.");
            return; // Зупинити обробку, якщо дані порожні
        }
        base.Handle(request);
    }
}
// Перевірити що дані не містять заборонених символів
public class ForbiddenCharsValidationHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Validating data content for user: {request.User}");
        // Логіка перевірки що дані не містять заборонених символів
        var forbiddenCharacters = new List<char> { '@', '#', '$', '%', '^', '&', '*' };
        if (request.Data.Any(c => forbiddenCharacters.Contains(c)))
        {
            Console.WriteLine("Data contains forbidden characters.");

            //request.IsSuccessful = false;
            //request.ErrorMessage = "Data contains forbidden characters.";

            return; // Зупинити обробку, якщо дані містять заборонені символи
        }
        base.Handle(request);
    }
}
// Якщо всі перевірки пройшли, обробити запит та вивести результат
public class ProcessingHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Processing request for user: {request.User}");
        // Логіка обробки запиту
        Console.WriteLine($"Data processed successfully: {request.Data}");
        base.Handle(request);
    }
}

public class NotifyAfterProcessHandler : RequestHandlerBase
{
    public override void Handle(Request request)
    {
        Console.WriteLine($"Notification: Request for user {request.User} has been processed.");
        base.Handle(request);
        
    }
}



public class Request
{
    public string User { get; set; }
    public string Password { get; set; }
    public string Data { get; set; }

    public bool? IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }

}



