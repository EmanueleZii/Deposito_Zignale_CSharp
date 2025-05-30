using System;

public interface IPiatto
{
    string Descrizione();
    string Prepara();
}

public class Pizza : IPiatto
{
    public string Descrizione()
    {
        return "Pizza";

    }
    public string Prepara()
    {
        return "Preparazione Base Pizza";
    }

}
public class Hamburger : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
    public string Prepara()
    {
        return "Preparazione Base Hamburger";
    }
}

public class Insalata : IPiatto
{
    public string Descrizione()
    {
        return "Hamburger";
    }
    public string Prepara()
    {
        return "Preparazione Base Hamburger";
    }
}

public abstract class IngredienteExtra : IPiatto
{
    protected IPiatto _piatto;
    public IngredienteExtra(IPiatto piatto)
    {
        piatto = _piatto;
    }

    public abstract string Descrizione();

    public string Prepara()
    {
        return _piatto.Prepara();
    }
}

public class ConBacon : IngredienteExtra
{
    public ConBacon(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return "Con Bacon";
    }

    public string Prepara()
    {
        return _piatto.Prepara() + "ConBacon";
    }
}
public class ConFormaggio : IngredienteExtra
{
    public ConFormaggio(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return "Con Formaggio";
    }

    public string Prepara()
    {
        return _piatto.Prepara() + "Con Formaggio";
    }
}

public class ConSalsa : IngredienteExtra
{
    public ConSalsa(IPiatto piatto) : base(piatto) { }

    public override string Descrizione()
    {
        return "Con Salsa";
    }

    public string Prepara()
    {
        return _piatto.Prepara() + "Con Salsa";
    }
}
public static class PiattoFactory {
    public static IPiatto Crea(string tipo)
    {
        switch (tipo.ToLower())
        {
            case "pizza":
                return new Pizza();
            case "Hamburer":
                return new Hamburger();
            case "Insalata":
                return new Insalata();
            default:
            throw new ArgumentException($"Tipo di piatto non riconosciuto: {tipo}");
        }
    }
}
public interface IPreparazioneStrategia
{
    string Prepara(string descrizione);
}

public class Fritto : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return "Fritto";
    }
}
public class Forno : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return "Forno";
    }
}

public class AllaGriglia : IPreparazioneStrategia
{
    public string Prepara(string descrizione)
    {
        return "Alla griglia";
    }
}

public class Chef
{
    private IPreparazioneStrategia _strategia;
    public Chef(IPreparazioneStrategia strategia) => _strategia = strategia;
    public string PreparaPiatto(IPiatto piatto)
    {
        return _strategia.Prepara(piatto.Descrizione());
    }
}


public class Programs
{
    public static void Main()
    {
        Console.WriteLine("Scegli un piatto base: pizza, hamburger, insalata");
        string tipo = Console.ReadLine();
        IPiatto piatto = PiattoFactory.Crea(tipo);

        bool aggiungi = true;

        while (aggiungi)
        {
            Console.WriteLine("Vuoi aggiungere un ingrediente extra? (formaggio, bacon, salsa, no)");
            string extra = Console.ReadLine();
            switch (extra.ToLower())
            {
                case "formaggio":
                    piatto = new ConFormaggio(piatto);
                    break;
                case "bacon":
                    piatto = new ConBacon(piatto);
                    break;
                case "salsa":
                    piatto = new ConSalsa(piatto);
                    break;
                case "no":
                    aggiungi = false;
                    break;
                default:
                    Console.WriteLine("Ingrediente non valido.");
                    break;
            }

        }
        // 3. Selezione strategia di preparazione
        Console.WriteLine("Scegli il tipo di cottura: fritto, alforno, allagriglia");
        string tipoCottura = Console.ReadLine();
        IPreparazioneStrategia str;

        switch (tipoCottura.ToLower())
        {
            case "fritto":
                str = new Fritto();
                break;
            case "forno":
                str = new Forno();
                break;
            case "griglia":
                str = new AllaGriglia();
                break;
            default:
                Console.WriteLine("Operazione non valida, uso cottura al forno");
                str = new Forno();
                break;
        }

        Chef chef = new Chef(str);

        // 4. Output finale
        Console.WriteLine("Descrizione piatto: " + piatto.Descrizione());
        Console.WriteLine("Preparazione: " + chef.PreparaPiatto(piatto));
    }
}