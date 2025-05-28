using System;
using System.Collections.Generic;

//Singleton Logger
public sealed class Logger
{
    //Instanza vuota del logger
    private static Logger instance;
    //Lista di log
    List<string> logMessages = new List<string>();
    //costruttore vuoto privato
    private Logger() { }
    // la proprieta con il get per verificare se l instanza è null
    public static Logger Instance
    {
        get
        {
            if (instance == null)
                instance = new Logger();

            return instance;
        }
    }
    //Il metodo per stampare il log
    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
        //aggiunge il log fatto alla lista
        logMessages.Add(message);
    }

    //metodo che stampa tutti i log aggiunti alla lista 
    public void StampaLog()
    {
        Console.WriteLine("--- LOG REGISTRATI ---");
        foreach (var log in logMessages)
        {
            Console.WriteLine(log);
        }
    }
}

public class Programs {
    public static void Main() {
        //instanze di logger
        Logger logger1 = Logger.Instance;
        Logger logger2 = Logger.Instance;

        bool continua = true;
        
        while (continua)
        {
            //menu
            Console.WriteLine("Scegli operazione");
            Console.WriteLine("1. Stampa tutti i log Registrati");
            Console.WriteLine("2. Aggiungi un log");
            Console.WriteLine("3. Aggiungi un secondo log");
            Console.WriteLine("4. Esci");

            int scelta = int.Parse(Console.ReadLine());

            string log2 = "";
            string log = "";

            switch (scelta)
            {
                case 1:
                    logger1.StampaLog();
                    logger2.StampaLog();
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
                    logger1.Log("scelta non valida");
                    break;
            }
        }
    }
}