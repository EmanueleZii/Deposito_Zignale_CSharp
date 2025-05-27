using System;

public sealed class Logger
{
    private static Logger instanza;
    private Logger() { }
    public static Logger GetInstance
    {
        get
        {
            if (instanza == null)
                instanza = new Logger();
            
            return instanza;
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {DateTime.Now} {message}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance;
        // Example usage of the Logger singleton
        Logger logger = Logger.GetInstance;
        logger.Log("This is a log message.");
    }
}
