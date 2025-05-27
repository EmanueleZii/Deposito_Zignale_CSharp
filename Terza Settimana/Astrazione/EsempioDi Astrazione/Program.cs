using System;
//classe Astratta
public abstract class Veicolo
{
    public abstract void Avvia();
}

//classe concreta che estende la classe Astratta
public class Auto : Veicolo
{
    public override void Avvia()
    {
        Console.WriteLine("L'auto è stata avviata.");
    }
}
//interfaccia
public interface IVeicoloElettrico
{
    void Ricarica();
}

//classe che implementa l'interfaccia
public class ScooterElettrica : Auto, IVeicoloElettrico
{
    public override void Avvia()
    {
        Console.WriteLine("L'auto elettrica è stata avviata.");
    }

    public void Ricarica()
    {
        Console.WriteLine("L'auto elettrica è in ricarica.");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Veicolo miaAuto = new Auto();
        miaAuto.Avvia();

        ScooterElettrica miaScooterElettrica = new ScooterElettrica();
        miaScooterElettrica.Avvia();
        miaScooterElettrica.Ricarica();
    }
}