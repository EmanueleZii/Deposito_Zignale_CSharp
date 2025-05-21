using System;

public class Program
{
    public static void Main(string[] args)
    {
        // Crea una  di film ooggetti
        List<Film> film = new List<Film>();
        Menu(film);
    }

    // Funzione per mostrare il menu
    public static void Menu(List<Film> film)
    {
        //menu
        Console.WriteLine("Benvenuto nella filmpedia!");
        Console.WriteLine("Scegli un'opzione:");
        Console.WriteLine("1. Aggiungi film");
        Console.WriteLine("2. Stampa film per genere");
        Console.WriteLine("3. Stampa tutti i film");
        Console.WriteLine("4. Esci");
        // Prende la scelta dell'utente
        int scelta = int.Parse(Console.ReadLine());
        // scelta dell'utente
        if (scelta <= 0)
            Console.WriteLine("Scelta non valida, riprova.");
        if (scelta > 4)
            Console.WriteLine("Scelta non valida, riprova.");
        switch (scelta)
        {
            case 1:
                AggiungiFilm(film);
                break;
            case 2:
                Console.WriteLine("Quale Film vuoi vedere? (Inserisci il genere)");
                string genere = Console.ReadLine();
                StampaFilmPerGenere(film, genere);
                break;
            case 3:
                StampaTuttiFilm(film);
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Scelta non valida, riprova.");
                break;
        }
    }
    public static void AggiungiFilm(List<Film> film) {

        Console.WriteLine("Quanti film vuoi aggiungere?");

        // Prende il numero di film dall'utente
        int numeroDiFilm = int.Parse(Console.ReadLine());

        // prende i dettagli dei film dall'utente
        for (int i = 0; i < numeroDiFilm; i++) {

            Console.WriteLine("Inserisci i film :");

            Console.Write("Titolo: ");
            string titolo = Console.ReadLine();

            Console.Write("Diretto: ");
            string diretto = Console.ReadLine();

            Console.Write("Anno: ");
            int anno = int.Parse(Console.ReadLine());

            // Valida l input per anno
            Console.Write("Genere: ");
            string genere = Console.ReadLine();

            // Aggiungi il film alla lista
            film.Add(new Film(titolo, diretto, anno, genere));
        }
        Menu(film);
    }
    // Stampa i film per genere
    public static void StampaFilmPerGenere(List<Film> film, string genere) {
        
        bool filmTrovato = false;
        
        // Stampa i film per genere
        foreach (Film f in film) {
            // Confronta il genere del film con quello inserito dall'utente
            if (f.Genere.Trim() == genere.Trim().ToLower()) {
                Console.WriteLine(f.ToString());
                filmTrovato = true;
            } else {
                Console.WriteLine("Nessun film trovato per il genere " + genere);
            }
        }
        Console.WriteLine("Premi un tasto per tornare al menu principale");
        Console.ReadKey();
        Console.Clear();
        // Torna al menu principale
        Menu(film);
    }

    // Stampa la lista dei film
    public static void StampaTuttiFilm(List<Film> film)
    {
        Console.WriteLine("Lista di film:");
        foreach (var f in film) {
            Console.WriteLine(f.ToString());
        }
        Console.WriteLine("Premi un tasto per tornare al menu principale");
        Console.ReadKey();
        Console.Clear();
        Menu(film);
    }
}

public class Film {
    public string Titolo = "",Diretto = "", Genere = "";
    public int Anno = 0;
    // Costruttore
    public Film(string title, string director, int year, string genere) {
        this.Titolo = title;
        this.Diretto = director;
        this.Anno = year;
        this.Genere = genere;
    }

    public override string ToString() {
        return $"{Titolo} ({Anno}) - Diretto da {Diretto}, Genere: {Genere}";
    }
}