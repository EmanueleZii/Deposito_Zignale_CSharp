using System;

public class Program
{
    public static void Main(string[] args) {

        // Inizializza una lista di stringhe
        List<string> lista = new List<string>();
        // Chiede all'utente di inserire gli elementi della lista
        Console.WriteLine("Inserisci gli elementi della lista della spesa:");

        // Inizializza una variabile per l'input dell'utente
        string input;
        int count = 0;

        //ciclo per aggiungere gli elementi alla lista
        // fino a 5 elementi o fino a quando l'utente non preme invio
        while (count <= 5)
        {
            Console.Write("Elemento (premi invio per terminare): ");
            input = Console.ReadLine();
            count++;
            // Se l'input è vuoto, esci dal ciclo
            if (string.IsNullOrEmpty(input))
                break;
            // Aggiunge l'elemento alla lista
            lista.Add(input);
            // Se la lista ha già 5 elementi, non aggiungere altri elementi
            if (lista.Count >= 5)
                break;
        }
        // Stampa gli elementi della lista
        Console.WriteLine("Lista della spesa:");
        for (int i = 0; i < lista.Count; i++) {
            Console.WriteLine($"Elemento {i + 1}: {lista[i]}");
        }
    }
}