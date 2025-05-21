using System;

public class Veicolo {
    
    public string Marca, Modello;

    public Veicolo(string marca, string modello){
        Marca = marca;
        Modello = modello;
    }
    public void StampaDettagli() {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello},");
    }
    public virtual string StampaInfo(string info) {
        return $"Info: {info}";
    }
}
public class Auto : Veicolo {
    public int NumeroPorte;

    public Auto(string marca, string modello, int numeroPorte) : base(marca, modello) {
        NumeroPorte = numeroPorte;
    }
    public int NumPorte(int numeroPorte) {
        return numeroPorte;
    }
    public override string StampaInfo(string info) {
        
        return $"Auto - {base.StampaInfo(info)}, Numero Porte: {NumeroPorte}";
    }
}
public class Moto : Veicolo {
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

    public static void Main(string[] args) {

        string marca, modello;
        int numeroPorte;
        bool haPortapacchi = false;

        List<Veicolo> veicoli = new List<Veicolo>();

        Console.WriteLine("Inserisci i dettagli del veicolo:");

        Console.WriteLine(" è una moto o un'auto? (1 per auto, 2 per moto):");
        int tipoVeicolo = int.Parse(Console.ReadLine());
        if (tipoVeicolo == 1) {
            Console.WriteLine("Auto");
            Console.WriteLine("Marca:");
            marca = Console.ReadLine();
            Console.WriteLine("Modello:");
            modello = Console.ReadLine();
            Console.WriteLine("Numero Porte:");
            numeroPorte = int.Parse(Console.ReadLine());
            veicoli.Add(new Auto(marca, modello, numeroPorte));
            Console.WriteLine("AUTO CREATA CON SUCCESSO");
        } else if (tipoVeicolo == 2) {
            Console.WriteLine("Moto");
            Console.WriteLine("Marca:");
            marca = Console.ReadLine();
            Console.WriteLine("Modello:");
            modello = Console.ReadLine();
            haPortapacchi = false;
            Console.WriteLine("Ha portapacchi? (true/false):");
            haPortapacchi = bool.Parse(Console.ReadLine());
            if (haPortapacchi) {
                veicoli.Add(new Moto(marca, modello, haPortapacchi));
            }else {
                veicoli.Add(new Moto(marca, modello, haPortapacchi));
            }
        } else {
            Console.WriteLine("Tipo di veicolo non valido.");
        }
        Console.WriteLine("Dettagli del veicolo:");
        foreach (var veicolo in veicoli)
        {
            veicolo.StampaDettagli();
            Console.WriteLine(veicolo.StampaInfo("Informazioni aggiuntive"));
        }
        Console.WriteLine("Premi un tasto per continuare...");
        Console.ReadKey();
        Console.WriteLine("Grazie per aver utilizzato il programma!");
        Console.WriteLine("Arrivederci!");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Programma terminato.");
    }
}