using System;
using System.Collections.Generic;

public class Animale
{
    public virtual void FaiVerso()
    {
        Console.WriteLine("L'animale fa un verso");
    }
}

public class Cane : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il cane abbaia");
    }
}
public class Gatto : Animale
{
    public override void FaiVerso()
    {
        Console.WriteLine("Il gatto miagola");
    }
}

public class Programs
{ 
    public static void Main(string[] args)
    {
        List<Animale> animali = new List<Animale>();
        animali.Add(new Cane());
        animali.Add(new Gatto());

        foreach (var animale in animali)
        {
            animale.FaiVerso();
        }
    }
}