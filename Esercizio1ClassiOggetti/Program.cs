using System;
/*19 maggio 2025 */
public class Studente {
    public string Nome;
    public int Matricola;
    public double MediaVoti;

    public Studente(string nome, int matricola, double mediaVoti){
        Nome = nome;
        Matricola = matricola;
        MediaVoti = mediaVoti;
    }
}

public class Program {
    
    public static void Main(string[] args) {

        Console.WriteLine("Benvenuto nel sistema di gestione studenti!");
        Console.WriteLine("Iniziamo a creare i tuoi studenti.");

        Studente studente1 = null;
        Studente studente2 = null;

        int student = 1;

        while (student <= 2) {

            Console.WriteLine($"Inserisci il nome dello studente {student}:");
            string nome = Console.ReadLine();

            Console.WriteLine($"Inserisci la matricola dello studente {student}:");
            int matricola = int.Parse(Console.ReadLine());

            Console.WriteLine($"Inserisci la media voti dello studente {student}:");
            double mediaVoti = double.Parse(Console.ReadLine());

            if (student == 1)
                studente1 = new Studente(nome, matricola, mediaVoti);
            else if (student == 2)
                studente2 = new Studente(nome, matricola, mediaVoti);

            student++;

            Console.WriteLine($"Studente creato con successo!");
        }
        Console.WriteLine($"Nome: {studente1.Nome}, Matricola: {studente1.Matricola}, Media Voti: {studente1.MediaVoti}");
        Console.WriteLine($"Nome: {studente2.Nome}, Matricola: {studente2.Matricola}, Media Voti: {studente2.MediaVoti}");
    }
}