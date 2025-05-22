using System;
using System.Collections.Generic;

public class Prenotazione {
    private int postiPrenotati;
    private int PostiDisponibili = 20;
    public string Destinazione { get; set; }
    public int postiDisponibili {
        get{ return PostiDisponibili;}
    }
    public int PostiPrenotati {

        get { return postiPrenotati; }
        set {
            if (postiPrenotati < 0)
            {
                Console.WriteLine("Il numero di posti prenotati deve essere maggiore di 0.");
                return;
            }
            else if (value > PostiDisponibili)
            {
                Console.WriteLine("Non ci sono abbastanza posti disponibili.");
            }
            else
            {
                postiPrenotati = value;
                PostiDisponibili -= value;
            }
        }
    }

    public int AnnullaPrenotazione(int postiannullati)
    {
        if (postiannullati > PostiPrenotati)
        {
            Console.WriteLine("Non puoi annullare più posti di quelli prenotati.");
            return PostiPrenotati;
        }
        else if (postiannullati < 0)
        {
            Console.WriteLine("Il numero di posti da annullare deve essere maggiore di 0.");
            return PostiPrenotati;
        }
        else if (PostiPrenotati == 0)
        {
            Console.WriteLine("Non hai prenotato nessun posto.");
            return PostiPrenotati;
        }
        else
        {
            PostiPrenotati -= postiannullati;
            PostiDisponibili += postiannullati;
            Console.WriteLine("Prenotazione annullata.");
            return PostiPrenotati;
        }
    }
    
    public int PrenotaPosti(int postiPrenotati)
    {
        PostiPrenotati++;
        Console.WriteLine("Prenotazione effettuata.");
        return PostiPrenotati;
    }

}



public class Program
{
    public static void Main() {
        Prenotazione prenotazione = new Prenotazione();
        bool continua = true;
        List<Prenotazione> prenota = new List<Prenotazione>();
        while (continua){
            Console.WriteLine("Benvenuto nel sistema di prenotazione!");
            Console.WriteLine("Scegli un'opzione:");
            Console.WriteLine("1. Prenota un viaggio");
            Console.WriteLine("2. Annulla una prenotazione");
            Console.WriteLine("3. Visualizza prenotazioni");
            Console.WriteLine("4. Esci");
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci la destinazione:");
                    prenotazione.Destinazione = Console.ReadLine().ToLower();
                    Console.WriteLine("Inserisci il numero di posti da prenotare:");
                    prenotazione.PostiPrenotati = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Posti disponibili: {prenotazione.postiDisponibili}");
                    prenota.Add(prenotazione);
                    Console.WriteLine("Prenotazione effettuata.");
                    break;
                case 2:
                    Console.WriteLine("Prenotazione annullata.");
                    Console.WriteLine("Inserisci la destinazione della prenotazione da annullare:");
                    string destinazione = Console.ReadLine().ToLower();
                    prenotazione = prenota.Find(p => p.Destinazione == destinazione);
                    if (prenotazione == null){
                        Console.WriteLine("Prenotazione non trovata.");
                        break;
                    }
                    Console.WriteLine("Inserisci il numero di posti da annullare:");
                    int postiAnnullati = int.Parse(Console.ReadLine());
                    prenotazione.AnnullaPrenotazione(postiAnnullati);
                    break;
                case 3:
                    Console.WriteLine("Visualizza prenotazioni:");
                    foreach (var p in prenota) {
                        Console.WriteLine($"Destinazione: {p.Destinazione}");
                        Console.WriteLine($"Posti prenotati: {p.PostiPrenotati}");
                        Console.WriteLine($"Posti disponibili: {p.postiDisponibili}");
                    }
                    break;
                default:
                    Console.WriteLine("Opzione non valida.");
                    break;
            }

        } 
    }


}
