using System;

public class Program
{
    public static void Main(string[] args)
    {
        Menu();
    }

    public static void Menu() {
            Utente utente = null;
            string motoreModificato = "";
            float velocitaMacModificata = 0;
            int sospensioniMaxModificate = 0;
            int nrModifiche = 0;
            string nomeUtente = "";
            int creditoUtente = 0;
            bool isloged = false;
            if (isloged == false) {
                Console.WriteLine("Inserisci il nome dell'utente:");
                nomeUtente = Console.ReadLine();
                Console.WriteLine("Inserisci il credito dell'utente:");
                creditoUtente = int.Parse(Console.ReadLine());
                utente = new Utente(nomeUtente, creditoUtente);
                Console.WriteLine($"Utente creato: {utente.Nome} con credito {utente.Credito}");
                isloged = true;
            }
            Console.WriteLine("1. Modifica Macchina");
            Console.WriteLine("2. Credito Disponibile");
            Console.WriteLine("3. Esci");
            Console.Write("Seleziona un'opzione: ");
            string input = Console.ReadLine();
        if (isloged == true) {
            switch (input) {
                case "1":
                    Console.WriteLine("Modifica Macchina:");
                    ModificaMacchina(utente.Credito, nrModifiche, motoreModificato, velocitaMacModificata, sospensioniMaxModificate);
                    Macchina auto = new Macchina(motoreModificato, velocitaMacModificata, sospensioniMaxModificate);
                    break;
                case "2":
                    Console.WriteLine($"Credito disponibile: {utente.Credito}");
                    break;
                case "3":
                    Console.WriteLine("Uscita dal programma...");
                    return;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }
    
    public static void ModificaMacchina(int crediti, int nrModifiche = 0, string motoreModificato = "", float velocitaMacModificata = 0, int sospensioniMaxModificate = 0) {
        while (crediti > 0) {
            Console.WriteLine("Modifica Macchina:");
            Console.WriteLine("1. Modifica Motore");
            Console.WriteLine("2. Modifica Velocità");
            Console.WriteLine("3. Modifica Sospensioni");
            Console.WriteLine("4. Esci");

            Console.Write("Seleziona un'opzione: ");
            string scelta = Console.ReadLine();

            switch (scelta) {
                case "1":
                    Console.WriteLine("Inserisci il nuovo motore:");
                    motoreModificato = Console.ReadLine();
                    Console.WriteLine($"Motore modificato in: {motoreModificato}");
                    nrModifiche++;
                    crediti--;
                    break;
                case "2":
                    Console.WriteLine("Inserisci la nuova velocità:");
                    velocitaMacModificata = float.Parse(Console.ReadLine());
                    Console.WriteLine($"Velocità modificata in: {velocitaMacModificata}");
                    nrModifiche++;
                    crediti--;
                    break;
                case "3":
                    Console.WriteLine("Inserisci il nuovo numero di sospensioni:");
                    sospensioniMaxModificate = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Sospensioni modificate in: {sospensioniMaxModificate}");
                    nrModifiche++;
                    crediti--;
                    break;
                case "4":
                    Console.WriteLine($"Modifiche effettuate: {nrModifiche}");
                    Console.WriteLine($"Credito rimanente: {crediti}");
                    Console.WriteLine($"Motore: {motoreModificato}");
                    Console.WriteLine($"Velocità: {velocitaMacModificata}");
                    Console.WriteLine($"Sospensioni: {sospensioniMaxModificate}");
                    Console.WriteLine($"Numero di modifiche: {nrModifiche}");
                    Menu();
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
            if (crediti <= 0) {
                Console.WriteLine("Credito esaurito. Non puoi effettuare ulteriori modifiche.");
                Menu();
            }
        }
    }
}

public class Utente { 
    public string Nome;
    public int Credito = 0;

    public Utente(string nome,  int credito)
    {
        Nome = nome;
        Credito = credito;
    }
}

public class Macchina
{
    public string Motore;
    public float VelocitaMac;
    public int SospensioniMax;
    public int nrModifiche;

    public Macchina(string motore, float velocitaMac, int sospensioniMax)
    {
        Motore = motore;
        VelocitaMac = velocitaMac;
        SospensioniMax = sospensioniMax;
        nrModifiche = 0;
    }
}