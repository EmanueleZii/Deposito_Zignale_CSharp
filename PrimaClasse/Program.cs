using System;

public class Cane
{
    public string Name = "";
    public int Age = 0;
    public void Abbaia()
    {
        Console.WriteLine($"{Name} dice bau");
    }
}

public class Programma
{ 
    public static void Main(string[] args)
    {
        // Creazione di un oggetto Cane
        // e inizializzazione dei suoi attributi
        Cane bau = new Cane();
        // Assegnazione dei valori alle proprietà
        bau.Name = "Fido";
        bau.Age = 3;
        // Stampa dei valori delle proprietà
        bau.Abbaia();
    }
}
