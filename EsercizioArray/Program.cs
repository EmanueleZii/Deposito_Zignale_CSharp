using System;

public class Program {
    public static void Main(string[] args)
    {
        // Esercizio 1
        //variabili
        int[] voti = new int[5];
        int somma = 0;
        int media = 0;
        int max = int.MaxValue;
        int min = int.MinValue;

        Console.WriteLine("Inserisci i voti (5 voti):");
        // ciclo for per inserire i voti
        for (int i = 0; i < voti.Length; i++)
        {
            // input dell'utente
            Console.Write($"Voto {i + 1}: ");
            voti[i] = int.Parse(Console.ReadLine());

            // somma voto
            somma += voti[i];
            // calcolo della media
            // media = somma / numero di voti
            media = somma / (i + 1);

            // calcolo del voto più alto e più basso
            if (voti[i] < min)
                min = voti[i];
            if (voti[i] > max)
                max = voti[i];
            // stampa dei voti
            Console.WriteLine($"Somma: {somma}");
            Console.WriteLine($"Media dei voti: {media}");
        }
        // stampa dei voti max e min
        Console.WriteLine($"\nVoto più basso: {min}");
        Console.WriteLine($"Voto più alto: {max}");
    }
}