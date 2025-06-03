using System;

//Esercizio 1
public interface INotifier
{
    void Notify(string message);
}
public class SmsNotifier : INotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"SMS inviato: {message}");
    }
}

public class AlertService
{
    public void SendAlert(string message, INotifier notifier)
    {
        notifier.Notify(message);
    }
}

//esercizio 2
public class Data
{
    public string Content { get; set; }
}

public interface IExportFormatter
{
    string Format(Data data);
}
public class JsonFormatter : IExportFormatter
{
    public string Format(Data data)
    {
        return $"{{ \"content\": \"{data.Content}\" }}";
    }
}

public class XmlFormatter : IExportFormatter
{
    public string Format(Data data)
    {
        return $"<data><content>{data.Content}</content></data>";
    }
}
public class DataExporter
{
    public void Export(Data data, IExportFormatter formatter)
    {
        string output = formatter.Format(data);
        Console.WriteLine($"Esportato: {output}");
    }
}

public class Programs
{
    public void Main()
    {
        
        // Esercizio 1 - Method Injection
        var alertService = new AlertService();
        var smsNotifier = new SmsNotifier();
        alertService.SendAlert("Attenzione! Metodo injection.", smsNotifier);

        // Esercizio 2 - Method Injection
        var data = new Data { Content = "Hello World" };
        var exporter = new DataExporter();
        exporter.Export(data, new JsonFormatter());
        exporter.Export(data, new XmlFormatter());
    }
}