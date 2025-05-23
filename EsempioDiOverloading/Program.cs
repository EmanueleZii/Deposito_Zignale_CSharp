using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

public class Program {

    public static void Main(string[] args)
    {
        Console.WriteLine(new Calcolatrice().Somma(10, 20));
        Console.WriteLine(new Calcolatrice().Somma(10.5, 20.5));
        Console.WriteLine(new Calcolatrice().Somma(10, 20, 30));
        List<Forma> forme = new List<Forma>(){
            new Rettangolo() { Base = 10, Altezza = 20 }
            , new Cerchio(10)
        };
    }
}

public class Calcolatrice
{
    
    public int Somma(int a, int b) => a + b;
    public double Somma(double a, double b) => a + b;
    public int Somma(int a, int b, int c) => a + b + c;

}

public class Forma
{
    public virtual double CalcolaArea()
    {
        return 0;
    }
}

public class Rettangolo : Forma
{
    public double Base { get; set; }
    public double Altezza { get; set; }

    public override double CalcolaArea()
    {
        return Base * Altezza;
    }
}
public class Cerchio : Forma
{
    public double Raggio { get; set; }

    public Cerchio(double raggio)
    {
        Raggio = raggio;
    }

    public override double CalcolaArea()
    {
        return Math.PI * Raggio * Raggio;
    }
}