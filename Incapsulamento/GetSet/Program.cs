using System;
using System.Collections.Generic;

public class ContoBancario {
    public string Nome { get; set; }
    public string Cognome { get; set; }
    private double saldo;

    // Proprietà per accedere al saldo
    // con un controllo per evitare valori negativi
    public double Saldo {
        get {
            return saldo;
        }
        set {
            if (value < 0)
                Console.WriteLine("Il saldo non può essere negativo.");
            else
                saldo = value;
        }
    }
}

public class Program {
    // Metodo Main per testare la classe ContoBancario
    public static void Main()
    {
        ContoBancario conto = new ContoBancario();
        conto.Nome = "Mario";
        conto.Cognome = "Rossi";
        conto.Saldo = 1000.0;
        Console.WriteLine($"Nome: {conto.Nome}");
        Console.WriteLine($"Cognome: {conto.Cognome}");
        Console.WriteLine($"Saldo: {conto.Saldo}");
        conto.Saldo = -500.0; // Questo non cambierà il saldo
    }

}