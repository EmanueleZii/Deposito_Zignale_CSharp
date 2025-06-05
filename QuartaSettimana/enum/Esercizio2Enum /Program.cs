using System;

public class Programs
{
    public enum LivelloDAccesso
    {
        Utente,
        Admin,
        Dev
    }
    public void Main()
    {
        Console.WriteLine("Seleziona livello di privilegio");
        Console.WriteLine("1.utente\n 2. Admin \n 3.Developer");
        string scelta = Console.ReadLine()?.Trim().ToLower();

        LivelloDAccesso livelloSelezionato = LivelloDAccesso.Utente;
        switch (scelta)
        {
            case "1":
            case "utente":
                livelloSelezionato = LivelloDAccesso.Utente;
                break;
            case "2":
            case "admin":
                livelloSelezionato = LivelloDAccesso.Admin;
                break;
            case "3":
            case "dev":
                livelloSelezionato = LivelloDAccesso.Dev;
                break;
            default:
                Console.WriteLine("login non valido");
                break;
        }
        
        Privilegi(livelloSelezionato);

    }

    public static void Privilegi(LivelloDAccesso livelloDAccesso)
    {
        switch (livelloDAccesso)
        {
            case LivelloDAccesso.Utente:
                Console.WriteLine("Accesso solo lettura e servizi.");
                break;
            case LivelloDAccesso.Admin:
                Console.WriteLine("Accesso ai strumenti della dashboard per la gestione del social.");
                break;
            case LivelloDAccesso.Dev:
                Console.WriteLine("Accesso al source code e strumenti di version control.");
                break;
        }
    }
}