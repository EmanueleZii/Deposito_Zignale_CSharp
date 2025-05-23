using System;
using System.ComponentModel.Design;

public class Veicolo
{
    private string Marca;
    private string Modello;
    private string AnnoImmatricolazione;
    public string marca
    {
        get
        {
            return Marca;
        }
        set
        {
            Marca = value;
        }
    }
    public string modello
    {
        get
        {
            return Modello;
        }
        set
        {
            Modello = value;
        }
    }
    public string annoImmatricolazione
    {
        get
        {
            return AnnoImmatricolazione;
        }
        set
        {
            AnnoImmatricolazione = value;
        }
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"{Marca}{Modello} {AnnoImmatricolazione}");
    }

    public Veicolo(string _marca, string _modello, string _annoImmatricolazione)
    {
        Marca = _marca;
        Modello = _modello;
        AnnoImmatricolazione = _annoImmatricolazione;
    }
}

public class AutoAziendale : Veicolo
{
    private string targa = "";
    private bool UsoPrivato = true;

    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"{targa}{UsoPrivato}");
    }

    public AutoAziendale(string _marca, string _modello, string _annoImmatricolazione, string _targa, bool _usoprivato) : base(_marca, _modello, _annoImmatricolazione)
    {
        _targa = targa;
        _usoprivato = UsoPrivato; 
    }

}
public class FurgoneAziendale : Veicolo
{
    private int CapacitaCarico ;
    public int capacitaCarico
    {
        get
        {
            return CapacitaCarico;
        }
        set
        {
            CapacitaCarico = CapacitaCarico;
        }
    }
    public override void StampaInfo()
    {
        base.StampaInfo();
        Console.WriteLine($"{CapacitaCarico}");
    }

    public FurgoneAziendale(string _marca, string _modello, string _annoImmatricolazione, int _capacitacarico) : base(_marca, _modello, _annoImmatricolazione)
    {
        _capacitacarico = capacitaCarico;
    }

}

public class Program
{
    public static void Main()
    {
        List<Veicolo> veicolo = new List<Veicolo>();
        Veicolo veicol = null;
        AutoAziendale autoAziendale = null;
        FurgoneAziendale furgoneAziendale = null;
        bool continua = true;
        string Marca;
        string Modello;
        string AnnoImmatricolazione;
        string targa = "";
        bool UsoPrivato = true;
        int capacitaCarico; 
        while (continua)
        {
            Menu();
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    StampaVeicoli(veicolo);
                    break;
                case 2: //veicolo
                    Console.WriteLine("Inserisci la Marca");
                    Marca = Console.ReadLine();
                    Console.WriteLine("Inserisci la Modello");
                    Modello = Console.ReadLine();
                    Console.WriteLine("Inserisci la AnnoImmatricolazione");
                    AnnoImmatricolazione = Console.ReadLine();
                    veicol = new Veicolo(Marca, Modello, AnnoImmatricolazione);
                    veicolo.Add(veicol);
                    break;
                case 3://Auto aziendale
                    Console.WriteLine("Inserisci la Marca");
                    Marca = Console.ReadLine();
                    Console.WriteLine("Inserisci la Modello");
                    Modello = Console.ReadLine();
                    Console.WriteLine("Inserisci Anno Immatricolazione");
                    AnnoImmatricolazione = Console.ReadLine();
                    Console.WriteLine("Inserisci Targa");
                    targa = Console.ReadLine();
                    Console.WriteLine("Uso Privato?");
                    UsoPrivato = bool.Parse(Console.ReadLine());
                    veicol = new AutoAziendale(Marca, Modello, AnnoImmatricolazione , targa, UsoPrivato);
                    veicolo.Add(veicol);
                    break;
                case 4: //furgone
                    Console.WriteLine("Inserisci la Marca");
                    Marca = Console.ReadLine();
                    Console.WriteLine("Inserisci la Modello");
                    Modello = Console.ReadLine();
                    Console.WriteLine("Inserisci la Modello");
                    AnnoImmatricolazione = Console.ReadLine();
                    Console.WriteLine("Inserisci la Modello");
                    capacitaCarico = int.Parse(Console.ReadLine());
                    veicol = new FurgoneAziendale(Marca, Modello, AnnoImmatricolazione, capacitaCarico);
                    veicolo.Add(veicol);
                    break;
                case 5:
                continua = false;
                Console.WriteLine("Uscita...");
                break;
                default:
                    Console.WriteLine("scelta non valida");
                    break;
            }
        }
    }

    public static void Menu()
    {
        Console.WriteLine("1 .Lista di Veicoli");
        Console.WriteLine("2 .crea un Veicolo");
        Console.WriteLine("3 .Crea un AutoAziendale");
        Console.WriteLine("4 .Crea un FurgoneAziendale");
        Console.WriteLine("5 .esci");
    }

    public static void StampaVeicoli(List<Veicolo> veicoli)
    {
        foreach (Veicolo v in veicoli)
        {
            v.StampaInfo();
        }
        
    }
}