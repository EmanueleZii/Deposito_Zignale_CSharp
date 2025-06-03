using System;
using System.Data.SqlTypes;
//esercizio 3
public interface ILogger
{
    void Log(string message);
}
public class ConsoleLogger : ILogger
{
    public void Log(string messagge)
    {
        Console.WriteLine($"LOG: {messagge}");
    }
}
public class Printer
{
    public ILogger _logger { get; set; }

    public void Print(string message)
    {
        _logger.Log($"User: {message} created.");
    }
}

//Esercizio 4
public interface IStorageService {
    public void Save(string fileName, int data);
}
public class DiskStorage : IStorageService {
    public void Save(string fileName, int data)
    {
        Console.WriteLine($"filecaricato{fileName} con dimensioni{data}mb");
    }
}

public class FileUploader {
    public IStorageService storageService { get; set; }
    public void Upload(string name, int data)
    {
        storageService.Save(name, data);
    }
}

public class Programs
{
    public void Main()
    {
        //esercizio 3
        var printer = new Printer();
        var printerlog = new ConsoleLogger();
        printer.Print("Ciao dal Printer!");

        // Setter Injection - Esercizio 4
        var uploader = new FileUploader();
        Console.WriteLine("Scegli storage (disk/memory):");
        string storage = Console.ReadLine();
        if (storage == "disk")
            uploader.storageService = new DiskStorage();
        else
            uploader.storageService = new DiskStorage();
        uploader.Upload("file.txt", 32);

    }
}