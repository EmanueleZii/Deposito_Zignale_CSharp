using System;
using System.Collections.Generic;

public class VoloAereo
{
    private int postiOccupati = 0;
    const int maxPosti = 150;
    public string CodiceVolo { get; set; }
    private int PostiLiberi;

    public VoloAereo()
    {
        PostiLiberi = maxPosti;
    }
    public int PostiOccupati
    {
        get { return postiOccupati; }
    }
    public int postiLiberi
    {
        get { return PostiLiberi - postiOccupati; }
    }

    public void EffettuaPrenotazione(int numeroPosti)
    {
        if (numeroPosti > (PostiLiberi - postiOccupati)) {
            Console.WriteLine("Non ci sono abbastanza posti disponibili.");
        }
        else if (numeroPosti <= 0) {
            Console.WriteLine("Il numero di posti deve essere maggiore di zero.");
        }
        else
        {
            postiOccupati += numeroPosti;
            Console.WriteLine($"Prenotazione effettuata per {numeroPosti} posti.");
        }
    }

    public int AnnullaPrenotazione(int numeroPosti)
    {
        return postiOccupati -= numeroPosti;
    }

    public void VisualizzaStato()
    {
        Console.WriteLine($"Codice Volo: {CodiceVolo}");
        Console.WriteLine($"Posti Occupati: {postiOccupati}");
        Console.WriteLine($"Posti Liberi: {PostiLiberi}");
    }
    public string GeneraCodiceVolo()
    {
        Random random = new Random();
        CodiceVolo = "AZ" + random.Next(100, 999).ToString();
        return CodiceVolo;
    }
}

public class Program
{
    public static void Main() {

        bool continua = true;
        string codiceVolocliente = "";

        // Creazione di uno oggetto VoloAereo se no si azzera il numero di postiOccupati
        VoloAereo volo = new VoloAereo();

        Console.WriteLine("Benvenuto nel sistema di prenotazione voli aerei.");
        while (continua) {

            StampaMenu();
            string scelta = Console.ReadLine();
            switch (scelta) {
                case "1":
                    Console.WriteLine("Inserisci il numero di posti da prenotare:");
                    int numeroPosti = int.Parse(Console.ReadLine());
                    codiceVolocliente = volo.GeneraCodiceVolo();
                    volo.EffettuaPrenotazione(numeroPosti);
                    Console.Clear();
                    volo.VisualizzaStato();
                    break;
                case "2":
                    Console.WriteLine("Inserisci il numero di posti da annullare:");
                    int postiDaAnnullare = int.Parse(Console.ReadLine());
                    volo.CodiceVolo = codiceVolocliente;
                    volo.AnnullaPrenotazione(postiDaAnnullare);
                    Console.Clear();
                    volo.VisualizzaStato();
                    break;
                case "3":
                    volo.CodiceVolo = codiceVolocliente;
                    volo.VisualizzaStato();
                    break;
                case "4":
                    Console.WriteLine("Uscita dal programma.");
                    continua = false;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }

    public static void StampaMenu()
    {
        Console.WriteLine("Scegli un'operazione:");
        Console.WriteLine("1. Effettua prenotazione");
        Console.WriteLine("2. Annulla prenotazione");
        Console.WriteLine("3. Visualizza stato volo");
        Console.WriteLine("4. Esci");
    }
}