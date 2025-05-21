using System;


public class Veicolo
{
    public string Marca;
    public string Modello;

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public void StampaDettagli()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello},");
    }

    public virtual string StampaInfo(string info)
    {
        return $"Info: {info}";
    }
}

public class Auto : Veicolo
{
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello) {
        NumeroPorte = numeroPorte;
    }
    public int NumPorte(int numeroPorte) {
        return numeroPorte;
    }
    public override string StampaInfo(string info)
    {
        return $"Auto - {base.StampaInfo(info)}, Numero Porte: {NumeroPorte}";
    }
}

public class Moto : Veicolo
{
    public bool HaPortapacchi;

    public Moto(string marca, string modello, bool haPortapacchi) : base(marca, modello)
    {
        HaPortapacchi = haPortapacchi;
    }

    public override string StampaInfo(string info)
    {
        return $"Moto - {base.StampaInfo(info)}, Ha Portapacchi: {HaPortapacchi}";
    }
}

public class Program {
    
    public static void Main(string[] args)
    {

        List<Veicolo> veicoli = new List<Veicolo>();
        Console.WriteLine("Inserisci il numero di veicoli da aggiungere:");
        int numeroVeicoli = int.Parse(Console.ReadLine());
        if (numeroVeicoli < 1 || numeroVeicoli > 2)
        {
            Console.WriteLine("Numero di veicoli non valido. Inserisci 1 o 2.");
            return;
        }
        switch (numeroVeicoli)
        {
            case 1:
                Console.WriteLine("Inserisci i dettagli del veicolo:");
                Console.WriteLine("Marca:");
                string marca = Console.ReadLine();
                Console.WriteLine("Modello:");
                string modello = Console.ReadLine();
                Console.WriteLine("Numero Porte:");
                int numeroPorte = int.Parse(Console.ReadLine());
                veicoli.Add(new Auto(marca, modello, numeroPorte));
                break;
            case 2:

                break;
            default:
                Console.WriteLine("Numero di veicoli non valido.");
                break;
        }
    }
}