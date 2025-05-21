using System;

public class Persona
{
    public string Nome;
    public string Cognome;
    public int AnnoNascita;
    
    public override string ToString()
    {
        return $"Nome: {Nome}, Cognome: {Cognome}, Anno di Nascita: {AnnoNascita}";
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
                Console.WriteLine("\n" + persona1);
            }
            else if (person == 2){
                persona2 = new Persona{ Nome = nome, Cognome = cognome, AnnoNascita = annoNascita };
                Console.WriteLine("\n" + persona2);
            }

            person++;

        }
    }
}