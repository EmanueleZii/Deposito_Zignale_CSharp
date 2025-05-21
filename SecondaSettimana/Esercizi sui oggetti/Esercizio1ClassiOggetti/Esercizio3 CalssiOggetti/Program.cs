using System;
/*20 maggio 2025*/
public class Program {
    // Metodo Main per eseguire il programma
    public static void Main(string[] args){
        // Creazione di un oggetto Libro e visualizzazione delle sue informazioni
        // Creazione di un oggetto Libro con titolo, autore e anno di pubblicazione
        Libro libro1 = new Libro("Il Signore degli Anelli", "J.R.R. Tolkien", 1954);
        Libro libro2 = new Libro("Il Signore degli Anelli", "J.R.R. Tolkien", 1954);
        Libro libro3 = new Libro("1984", "George Orwell", 1949);
        Console.WriteLine(libro1);
        Console.WriteLine(libro2.Equals(libro2)); // true
        Console.WriteLine(libro1.Equals(libro3)); // false
        Console.WriteLine(libro1.GetHashCode());
    }
}

public class Libro {
    public string Titolo;
    public string Autore;
    public int AnnoPubblicazione;

    // Costruttore della classe Libro
    // Inizializza le proprietà del libro
    public Libro(string titolo, string autore, int annoPubblicazione) {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = annoPubblicazione;
    }
    // Metodo per visualizzare le informazioni del libro
    // Override del metodo ToString per restituire una rappresentazione testuale del libro
    public override string ToString() {
        return $"{Titolo} di {Autore}, pubblicato nel {AnnoPubblicazione}";
    }
    // Override del metodo Equals per confrontare due oggetti Libro
    public override bool Equals(object obj) {
        if (obj is Libro libro)
            return Titolo == libro.Titolo && Autore == libro.Autore && AnnoPubblicazione == libro.AnnoPubblicazione;

        return false;
    }
    // Override del metodo GetHashCode per restituire un codice hash unico per ogni libro
    public override int GetHashCode()
    {
        return HashCode.Combine(Titolo, Autore, AnnoPubblicazione);
    }
}


