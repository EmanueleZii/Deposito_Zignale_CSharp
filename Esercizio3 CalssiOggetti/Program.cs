using System;
/*20 maggio 2025*/
public class Program {
    public static void Main(string[] args) {
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

    public Libro(string titolo, string autore, int annoPubblicazione) {
        Titolo = titolo;
        Autore = autore;
        AnnoPubblicazione = annoPubblicazione;
    }
    public override string ToString() {
        return $"{Titolo} di {Autore}, pubblicato nel {AnnoPubblicazione}";
    }
    public override bool Equals(object obj){
        if (obj is Libro libro)
            return Titolo == libro.Titolo && Autore == libro.Autore && AnnoPubblicazione == libro.AnnoPubblicazione;
    
        return false;
    }
    public override int GetHashCode() {
        return HashCode.Combine(Titolo, Autore, AnnoPubblicazione);
    }
}


