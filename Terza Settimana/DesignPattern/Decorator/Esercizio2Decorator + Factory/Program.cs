using System;

// 1. Component: definisce l'interfaccia dell'oggetto
public interface ITorta {
    string Descrizione();

}
// 2. ConcreteComponent: oggetto base senza decorazioni
public class TortaCioccolato : ITorta
{
    public string Descrizione()
    {
        return "Torta al cioccolato";
    }
    
}
public class TortaVaniglia : ITorta
{
    public string Descrizione()
    {
        return "Torta alla vaniglia";
    }
}
public class TortaFrutta : ITorta
{
    public string Descrizione()
    {
        return "Torta alla frutta";
    }
}
// 3. Decorator: classe astratta che implementa IComponent 
//    e incapsula un IComponent interno
public abstract class DecoratoratoreTorta : ITorta
{
    // Riferimento al componente "decorato"
    protected ITorta _baseTorta;

    // Costruttore: richiede un componente da decorare
    protected DecoratoratoreTorta(ITorta torta)
    {
        _baseTorta = torta;
    }
    public abstract string Descrizione();
    // Delegazione dell'operazione al componente interno
    public override string ToString()
    {
        return base.ToString();
    }
}
// 4. ConcreteDecoratorA: aggiunge comportamento prima e dopo la chiamata
public class ConPanna : DecoratoratoreTorta
{
    ITorta torta;
    public ConPanna(ITorta bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        torta.Descrizione();
        return "Con Latte";
    }
}

public class ConGlassa : DecoratoratoreTorta
{
    ITorta torta;
    public ConGlassa(ITorta bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        torta.Descrizione();
        return "Con Glassa";
    }
}
public class ConFragole : DecoratoratoreTorta
{
    ITorta torta;
    public ConFragole(ITorta bevanda) : base(bevanda) { }

    public override string Descrizione()
    {
        torta.Descrizione();
        return "Con Fragole";
    }
}
// Factory per le torte base
public static class TortaFactory
{
    public static ITorta CreaTortaBase(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "cioccolato":
                return new TortaCioccolato();
            case "vaniglia":
                return new TortaVaniglia();
            case "frutta":
                return new TortaFrutta();
            default:
                Console.WriteLine("Tipo torta non valido");
                return null;
        }
    }
}
//Programma
class Program
{
    static void Main() {
        Console.WriteLine("Scegli la torta base: (cioccolato/vaniglia/frutta)");
        string sceltaBase = Console.ReadLine();
        ITorta torta = null;
        try {
            torta = TortaFactory.CreaTortaBase(sceltaBase);
        }
        catch {
            Console.WriteLine("Torta non valida.");
            return;
        }

        bool aggiungi = true;
        while (aggiungi)
        {
            Console.WriteLine("Vuoi aggiungere un ingrediente? (panna/fragole/glassa/nessuno)");
            string ingr = Console.ReadLine().ToLower();
            switch (ingr)
            {
                case "panna":
                    torta = new ConPanna(torta);
                    break;
                case "fragole":
                    torta = new ConFragole(torta);
                    break;
                case "glassa":
                    torta = new ConGlassa(torta);
                    break;
                case "nessuno":
                    aggiungi = false;
                    break;
                default:
                    Console.WriteLine("Ingrediente non valido.");
                    break;
            }
        }
        Console.WriteLine("Descrizione finale: " + torta.Descrizione());
    }
}