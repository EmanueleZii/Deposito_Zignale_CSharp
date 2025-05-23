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
    public static void Main() {

        // Creazione di un oggetto di tipo Animale
        List<Animale> animali = new List<Animale>();

        animali.Add(new Cane());
        animali.Add(new Gatto());
        // Creazione di un oggetto di tipo Cane
        Cane cane = new Cane();

        if (cane is Animale)
            Console.WriteLine("Il cane è un animale");
        
        foreach (var animale in animali) {
            animale.FaiVerso();
        }
    }
}