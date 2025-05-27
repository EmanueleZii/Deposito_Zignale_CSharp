using System;

public abstract class Animale
{
    public abstract void FaiVerso();
    public void Dormi() => Console.WriteLine("L'animale dorme.");
}

public interface IVeicolo {
    void Avvia();
}

public class Moto : IVeicolo {
    public void Avvia() => Console.WriteLine("La moto è stata avviata.");
}