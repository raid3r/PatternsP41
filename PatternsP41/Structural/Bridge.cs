using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsP41.Structural;


public class BridgeExampleClientCode
{
    public void Run()
    {
        var inputFormat = "xml";
        var outputFormat = "json";

        IFileReader fileReader = inputFormat switch
        {
            "json" => new JsonFileReader(),
            "xml" => new XmlFileReader(),
            "txt" => new TxtFileReader(),
            "csv" => new CsvFileReader(),
            _ => throw new NotSupportedException($"Unsupported input format: {inputFormat}")
        };

        IFileWriter fileWriter = outputFormat switch
        {
            "json" => new JsonFileWriter(),
            "xml" => new XmlFileWriter(),
            "txt" => new TxtFileWriter(),
            "jpeg" => new JpegFileWriter(),
            _ => throw new NotSupportedException($"Unsupported output format: {outputFormat}")
        };


        var fileManager = new FileManager(
            fileReader: fileReader,
            fileWriter: fileWriter
            );

        var inputFile = "data.txt";
        var outputFile = "data.json";

        var content = fileManager.ReadFromFile(inputFile);
        fileManager.WriteToFile(outputFile, content);

        fileManager.FileWriter = new XmlFileWriter();
        fileManager.WriteToFile(outputFile, content);

    }
}

public interface IFileWriter
{
    void WriteToFile(string filePath, string content);
}

public interface IFileReader
{
    string ReadFromFile(string filePath);
}

class JsonFileWriter : IFileWriter
{
    public void WriteToFile(string filePath, string content)
    {
        Console.WriteLine($"Writing to JSON file: {filePath} with content: {content}");
        // Реалізація запису в JSON файл
    }
}

class XmlFileWriter : IFileWriter
{
    public void WriteToFile(string filePath, string content)
    {
        Console.WriteLine($"Writing to XML file: {filePath} with content: {content}");
        // Реалізація запису в XML файл
    }
}

class TxtFileWriter : IFileWriter
{
    public void WriteToFile(string filePath, string content)
    {
        Console.WriteLine($"Writing to TXT file: {filePath} with content: {content}");
        // Реалізація запису в TXT файл
    }
}

class JpegFileWriter : IFileWriter
{
    public void WriteToFile(string filePath, string content)
    {
        Console.WriteLine($"Writing to JPEG file: {filePath} with content: {content}");
        // Реалізація запису в JPEG файл
    }
}

class JsonFileReader : IFileReader
{
    public string ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading from JSON file: {filePath}");
        // Реалізація читання з JSON файлу
        return $"Content of {filePath} in JSON format";
    }
}

class XmlFileReader : IFileReader
{
    public string ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading from XML file: {filePath}");
        // Реалізація читання з XML файлу
        return $"Content of {filePath} in XML format";
    }
}

class TxtFileReader : IFileReader
{
    public string ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading from TXT file: {filePath}");
        // Реалізація читання з TXT файлу
        return $"Content of {filePath} in TXT format";
    }
}

class CsvFileReader : IFileReader
{
    public string ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading from CSV file: {filePath}");
        // Реалізація читання з CSV файлу
        return $"Content of {filePath} in CSV format";
    }
}


class FileManager
{
    public FileManager(IFileReader fileReader, IFileWriter fileWriter)
    {
        FileReader = fileReader;
        FileWriter = fileWriter;
    }

    public IFileReader FileReader { get; set; }
    public IFileWriter FileWriter { get; set; }

    public void WriteToFile(string filePath, string content)
    {
        Console.WriteLine($"Writing to file: {filePath} with content: {content}");
        FileWriter.WriteToFile(filePath, content);
    }

    public string ReadFromFile(string filePath)
    {
        Console.WriteLine($"Reading from file: {filePath}");
        return FileReader.ReadFromFile(filePath);
    }

    public void TransformFile(string inputFilePath, string outputFilePath)
    {
        var content = ReadFromFile(inputFilePath);
        WriteToFile(outputFilePath, content);
    }


}

