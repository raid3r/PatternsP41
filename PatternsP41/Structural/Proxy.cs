using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;



public class ProxyExampleClientCode
{
    public void Run()
    {
        var now = DateTime.Now;
        
        var database = new CacheProxy(new Lazy<IDatabase>(() => new Database()));
        //var database = new Database();

        for (int i = 0; i < 3; i++)
        {
            var data = database.GetData("KEY-1");
            Console.WriteLine(data);
        }
        var data2 = database.GetData("KEY-2");
        Console.WriteLine(data2);

        var data3 = database.GetData("KEY-2");
        Console.WriteLine(data3);

        var diff = DateTime.Now - now;
        Console.WriteLine($"Total time taken: {diff.TotalSeconds} seconds");

    }
}

public interface IDatabase
{
    string GetData(string key);
}


class CacheProxy : IDatabase
{
    private readonly Lazy<IDatabase> _database;
    private readonly Dictionary<string, string> _cache;
    public CacheProxy(Lazy<IDatabase> database)
    {
        _database = database;
        _cache = new Dictionary<string, string>() {
            ["KEY-1"] = "Cached data for KEY-1" 
        };
    }
    public string GetData(string key)
    {
        if (_cache.ContainsKey(key))
        {
            Console.WriteLine("Retrieving data from cache...");
            return _cache[key];
        }
        else
        {
            var data = _database.Value.GetData(key);
            _cache[key] = data;
            return data;
        }
    }
}


class Database : IDatabase
{
    public Database()
    {
        Console.WriteLine("Initializing database connection...");
        Thread.Sleep(3000); // Simulate a delay in establishing a connection
        Console.WriteLine("Database connection established.");
    }

    public string GetData(string key)
    {
        Console.WriteLine($"Getting data for key: {key} from the database...");
        Thread.Sleep(2000); // Simulate a delay in fetching data
        return $"Data for key: {key} from database";
    }
}
