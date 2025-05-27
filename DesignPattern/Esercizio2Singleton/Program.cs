using System;
using System.Collections.Generic;
public sealed class Logger {
    private static Logger instance;
    List<string> logMessages = new List<string>();
    private Logger() { }
    public static Logger Instance
    {
        get
        {
            if (instance == null)
                instance = new Logger();

            return instance;
        }
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
        logMessages.Add(message);
    }

    public void StampaLog() {
        foreach (var log in logMessages) {
            Console.WriteLine(log);
        }
    }
}

public class Programs
{
    public void Main()
    {
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("Scegli operazione");
            Console.WriteLine("1. stampa tutti i log");
            Console.WriteLine("2. aggiungi un log");
            Console.WriteLine("3. aggiungi un secondo log");
            Console.WriteLine("4. Esci");
            int scelta = int.Parse(Console.ReadLine());
            string log2 = "";
            string log = "";
            switch (scelta)
            {
                case 1:
                    logger1.StampaLog();
                    //logger2.StampaLog();
                    break;
                case 2:
                    Console.WriteLine("Inserisci il log da aggiungere:");
                    log = Console.ReadLine();
                    logger1.Log(log);
                    break;
                case 3:
                    Console.WriteLine("Inserisci il log da aggiungere:");
                    log2 = Console.ReadLine();
                    logger2.Log(log2);
                    break;
                case 4:
                    continua = false;
                    break;
                default:
                    logger1.Log("Default case executed");
                    break;
            }
        }
    }
}