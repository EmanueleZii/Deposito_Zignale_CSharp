using System;
using System.Collections.Generic;

//classe padre Operatore
public class Operatore
{
    private string nome { get; set; }
    private string turno { get; set; }
    public string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            nome = value;
        }
    }
    public string Turno
    {
        get
        {
            return turno;
        }
        set
        {
            turno = value;
        }
    }

    public virtual void EseguiCompito()
    {
        Console.WriteLine("Operatore generico in servizio.");
    }
}
//classe figlia OperatoreEmergenza
public class OperatoreEmergenza : Operatore
{
    private int livelloEmergenza;
    public int LivelloEmergenza
    {
        get
        {
            return livelloEmergenza;
        }
        set
        {
            if (value < 1 || value > 5)
            {
                throw new ArgumentOutOfRangeException("LivelloEmergenza deve essere compreso tra 1 e 5.");
            }
            else
            {
                livelloEmergenza = value;
            }
        }
    }
    public override void EseguiCompito()
    {
        base.EseguiCompito();
        Console.WriteLine("Operatore di macchina in servizio.");
    }
}
//classe figlia OperatoreSicurezza
public class OperatoreSicurezza : Operatore
{
    private string AreaSorvegliata;
    public string areasorvegliata
    {
        get
        {
            return AreaSorvegliata;
        }
        set
        {
            AreaSorvegliata = value;
        }
    }
    public override void EseguiCompito()
    {
        base.EseguiCompito();
        Console.WriteLine("Sorveglianza Area x.");
    }
}

//classe figlia OperatoreLogistica
public class OpratoreLogitica : Operatore
{
    private int NumeroConsegne;
    public int numeroconsegne
    {
        get
        {
            return NumeroConsegne;
        }
        set
        {
            NumeroConsegne = value;
        }
    }
    public override void EseguiCompito()
    {
        base.EseguiCompito();
        Console.WriteLine("Coordinamento di x consegne.");
    }
}

//classe Program con metodo Main
public class Program
{
    // Metodo Main
    // Questo è il punto di ingresso principale per l'applicazione.
    public static void Main()
    {
        // Creazione di variabili per gli operatori
        // Queste variabili sono inizializzate a null e verranno assegnate più tardi.
        OperatoreEmergenza operatoreEmergenza = null;
        OperatoreSicurezza operatoreSicurezza = null;
        OpratoreLogitica operatoreLogistica = null;
        Operatore operatoreGenerico = null;
        // Creazione di una lista di operatori
        List<Operatore> operatori = new List<Operatore>();
        // Inizializzazione di un ciclo per continuare a chiedere all'utente
        bool continua = true;
        while (continua)
        {
            // Stampa del menu per la selezione del tipo di operatore
            // e per eseguire altre operazioni
            Menu();
            string scelta = Console.ReadLine();
            // Controllo della scelta dell'utente
            // Se l'utente sceglie un numero da 1 a 7, viene creato un nuovo operatore
            switch (scelta)
            {
                case "1":
                    operatoreEmergenza = new OperatoreEmergenza();
                    operatori.Add(operatoreEmergenza);
                    break;
                case "2":
                    operatoreSicurezza = new OperatoreSicurezza();
                    operatori.Add(operatoreSicurezza);
                    break;
                case "3":
                    operatoreLogistica = new OpratoreLogitica();
                    operatori.Add(operatoreLogistica);
                    break;
                case "4":
                    operatoreGenerico = new Operatore();
                    operatori.Add(operatoreGenerico);
                    break;
                case "5":
                    StampaListaOperatori(operatori);
                    break;
                case "6":
                    Console.WriteLine("tuutti gli operatori in servizio");
                    // Esegui il compito per ogni operatore
                    foreach (Operatore operatore in operatori)
                    {
                        operatore.EseguiCompito();
                    }
                    break;
                case "7":
                    Console.WriteLine("Uscita dal programma.");
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }

    }
    public static void Menu()
    {
        Console.WriteLine("Seleziona il tipo di operatore da creare:");
        Console.WriteLine("1. Operatore Emergenza");
        Console.WriteLine("2. Operatore Sicurezza");
        Console.WriteLine("3. Operatore Logistica");
        Console.WriteLine("4. Operatore Generico");
        Console.WriteLine("5. Stampa lista operatori");
        Console.WriteLine("6. Esegui compito");
        Console.WriteLine("7. Esci");
    }
    public static void StampaListaOperatori(List<Operatore> operatori)
    {
        foreach (Operatore operatore in operatori)
        {
            Console.WriteLine($"Nome: {operatore.Nome}, Turno: {operatore.Turno}");
        }
    }
}