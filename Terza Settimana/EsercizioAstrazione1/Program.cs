using System;
using System.Collections.Generic;

public abstract class DispositivoElettrico
{
    public string Modello { get; set; }

    public abstract void Accendi();
    public abstract void Spegni();
    public abstract void MostraInfo();
}

public class Computer : DispositivoElettrico
{
    public override void Accendi()
    {
        Console.WriteLine($"{Modello} acceso.");
    }

    public override void Spegni()
    {
        Console.WriteLine($"{Modello} spento.");
    }

    public override void MostraInfo()
    {
        Console.WriteLine($"Computer Modello: {Modello}");
    }
}
public class Stampante : DispositivoElettrico
{
    public override void Accendi()
    {
        Console.WriteLine($"{Modello} acceso.");
    }

    public override void Spegni()
    {
        Console.WriteLine($"{Modello} spento.");
    }

    public override void MostraInfo()
    {
        Console.WriteLine($"Stampante Modello: {Modello}");
    }

}


public class Program
{
    public static void Main()
    {
        List<DispositivoElettrico> dispositivi = new List<DispositivoElettrico>(); 
        bool esegui = true;
        while (esegui) {
            Menu();
            string scelta = Console.ReadLine();
            switch (scelta) {
                case "1":
                    Console.WriteLine("Inserisci il modello del Computer:");
                    string modelloComputer = Console.ReadLine();
                    dispositivi.Add(new Computer { Modello = modelloComputer });
                    break;
                case "2":
                    Console.WriteLine("Inserisci il modello della Stampante:");
                    string modelloStampante = Console.ReadLine();
                    dispositivi.Add(new Stampante { Modello = modelloStampante });
                    break;
                case "3":
                    StampaTutto(dispositivi);
                    break;
                case "4":
                    Console.WriteLine("Inserisci il modello del dispositivo da accendere:");
                    string modelloDaAccendere = Console.ReadLine();
                    DispositivoElettrico dispositivoTrovato = dispositivi.Find(d => d.Modello.Equals(modelloDaAccendere));
                    if (dispositivoTrovato != null)
                        dispositivoTrovato.Accendi();
                    else
                        Console.WriteLine("Dispositivo non trovato.");
                break;
                case "5":
                    Console.WriteLine("Inserisci il modello del dispositivo da spegnere:");
                    string modelloDaSpegnere = Console.ReadLine();
                    DispositivoElettrico dispositivoDaSpegnere = dispositivi.Find(d => d.Modello.Equals(modelloDaSpegnere));
                    if (dispositivoDaSpegnere != null)
                        dispositivoDaSpegnere.Spegni();
                    else
                        Console.WriteLine("Dispositivo non trovato.");
                    break;
                case "6":
                    esegui = false;
                    break;
                default:
                    Console.WriteLine("Opzione non valida, riprova.");
                    break;
            }
        }
    }

    public static void Menu()
    { 
        Console.WriteLine("Scegli un'opzione:");
        Console.WriteLine("1. Crea un nuovo Computer");
        Console.WriteLine("2. Crea una nuova Stampante");
        Console.WriteLine("3. Mostra informazioni su tutti i dispositivi");
        Console.WriteLine("4. Accendi un dispositivo");
        Console.WriteLine("5. Spegni un dispositivo");
        Console.WriteLine("6. Esci");
    }

    public static void StampaTutto(List<DispositivoElettrico> dispositivi)
    {
        foreach (var dispositivo in dispositivi)
        {
            dispositivo.Accendi();
            dispositivo.MostraInfo();
            dispositivo.Spegni();
        }
    }
}