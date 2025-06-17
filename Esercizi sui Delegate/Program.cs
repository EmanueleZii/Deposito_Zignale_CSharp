using System;
using System.IO;

    // Esercizio 1
    delegate int Operazione(int a, int b);
    // Esercizio 2
    delegate void Logger(string messaggio);
    class Program {
        
        static void Main()
        {
            // Esercizio 1
            Operazione somma = Somma;
            Operazione moltiplica = Moltiplica;

            Console.WriteLine("Somma: " + EseguiOperazione(5, 3, somma));
            Console.WriteLine("Moltiplicazione: " + EseguiOperazione(5, 3, moltiplica));

            // Esercizio 2
            Logger logger = StampaConsole;
            logger += LogFittizio;

            logger("Questo è un messaggio di log.");
        }
        static int Somma(int a, int b)
        {
            return a + b;
        }
        static int Moltiplica(int a, int b)
        {
            return a * b;
        }
        static int EseguiOperazione(int a, int b, Operazione op)
        {
            return op(a, b);
        }
        static void StampaConsole(string messaggio)
        {
            Console.WriteLine("Console: " + messaggio);
        }

        static void LogFittizio(string messaggio)
        {
            Console.WriteLine("LogFittizio: " + messaggio);   
        }
}
