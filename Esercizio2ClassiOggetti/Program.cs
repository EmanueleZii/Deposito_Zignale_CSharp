using System;

public class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoNascita;
    public Persona(string nome, string Cognome, int AnnoNascita)
    {
        this.Nome = nome;
        this.Cognome = Cognome;
        this.AnnoNascita = AnnoNascita;
    }
}

public class Program
{
    public static void Main(string[] args){
        Persona persona1 = null;
        Persona persona2 = null;
        Console.WriteLine("Benvenuto nel programma di gestione delle persone!");
        int person = 0;
        
        while (person <= 2){

            Console.WriteLine($"Inserisci i dati della persona {person}:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Cognome: ");
            string cognome = Console.ReadLine();
            Console.Write("Anno di nascita: ");
            int annoNascita = int.Parse(Console.ReadLine());

            if (person == 1) {
                persona1 = new Persona { Nome = nome, Cognome = cognome, AnnoNascita = annoNascita };
                Console.WriteLine("\n Nome e cognome della persona 1: " + persona1.Nome + " " + persona1.Cognome + " Data Di Nascita " + persona1.AnnoNascita);
            } else if (person == 2) {
                persona2 = new Persona { Nome = nome, Cognome = cognome, AnnoNascita = annoNascita };
                Console.WriteLine("\n Nome e cognome della persona 1: " + persona2.Nome + " " + persona2.Cognome + " Data Di Nascita " + persona2.AnnoNascita);
            }

            person++;

        }
    }
}