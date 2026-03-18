using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Creational;



public class AbstarctFactoryExampleClientCode
{
    public void Run()
    {
        var theme = "light"; // Це може бути "light" або "dark", залежно від потреб
        ISiteFactory siteFactory = theme switch
        {
            "light" => new LightSiteFactory(),
            "dark" => new DarkSiteFactory(),
            "green" => new GreenSiteFactory(),
            _ => throw new ArgumentException("Unknown theme")
        };

        var site = new Site
        {
            Header = siteFactory.CreateHeader(),
            Body = siteFactory.CreateBody()
        };
        site.Render();
    }
}


public interface IHeader
{
    void RenderHeader();
}

public interface IBody
{
    void RenderBody();
}


public class LightHeader: IHeader
{
    public void SomeMethod()
    {
        Console.WriteLine("Some method in LightHeader");
    }

    public void RenderHeader()
    {
        Console.WriteLine("Rendering light header...");
    }
}

public class  LightBody: IBody
{
    public void RenderBody()
    {
        Console.WriteLine("Rendering light body...");
    }
}

public class DarkHeader: IHeader
{
    public void RenderHeader()
    {
        Console.WriteLine("Rendering dark header...");
    }
}

public class DarkBody : IBody
{
    public void RenderBody()
    {
        Console.WriteLine("Rendering dark body...");
    }
}

public interface ISiteFactory
{
    IHeader CreateHeader();
    IBody CreateBody();
}

public class LightSiteFactory : ISiteFactory
{
    public IHeader CreateHeader()
    {
        return new LightHeader();
    }
    public IBody CreateBody()
    {
        return new LightBody();
    }
}

public class DarkSiteFactory : ISiteFactory
{
    public IHeader CreateHeader()
    {
        return new DarkHeader();
    }
    public IBody CreateBody()
    {
        return new DarkBody();
    }
}



public class Site
{
    public IHeader Header { get; set; }
    public IBody Body { get; set; }

    public void Render()
    {
        Header.RenderHeader();
        Body.RenderBody();
    }
}



public class GreenHeader : IHeader
{
    public void RenderHeader()
    {
        Console.WriteLine("Rendering green header...");
    }
}

public class GreenBody : IBody
{
    public void RenderBody()
    {
        Console.WriteLine("Rendering green body...");
    }
}

public class GreenSiteFactory : ISiteFactory
{
    public IHeader CreateHeader()
    {
        return new GreenHeader();
    }
    public IBody CreateBody()
    {
        return new GreenBody();
    }
}