using System;

public class Program {
    public static void Main(string[] args) {

        int[] voti = new int[5];
        int somma = 0;
        int media = 0;

        Console.WriteLine("Inserisci i voti (5 voti):");

        for (int i = 0; i < voti.Length; i++)
        {
            Console.Write($"Voto {i + 1}: ");
            voti[i] = int.Parse(Console.ReadLine());
            somma += voti[i];
            media = somma / (i + 1);
            Console.WriteLine($"Somma: {somma}");
            Console.WriteLine($"Media dei voti: {media}");
        }
    }
}