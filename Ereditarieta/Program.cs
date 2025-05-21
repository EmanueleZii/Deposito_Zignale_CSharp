using System;

public class Animale
{
    public string Nome { get; set; }
    public int Eta { get; set; }

    public Animale(string nome, int eta)
    {
        Nome = nome;
        Eta = eta;
    }

    public virtual void Verso()
    {
        Console.WriteLine("L'animale fa un verso.");
    }
}

public class Cane : Animale
{
    public Cane(string nome, int eta) : base(nome, eta)
    {

    }

    public override void Verso()
    {
        Console.WriteLine("Il cane abbaia.");
    }
}