using System;
// Design Pattern Factory Method

//  IVeicolo : definisce l'interfaccia del prodotto
public interface IVeicolo {
    void Avvia();
    void MostraTipo();
}
// 2. Auto: implementa IVeicolo
public class Auto : IVeicolo {
    public void Avvia() {
        Console.WriteLine("Auto avviata.");
    }
    public void MostraTipo() {
        Console.WriteLine("Tipo: Auto");
    }
}
// 3. Moto: implementa IVeicolo
public class Moto : IVeicolo {
    public void Avvia() {
        Console.WriteLine("Moto avviata.");
    }
    public void MostraTipo() {
        Console.WriteLine("Tipo: Moto");
    }
}
// 2. Camion: implementa IVeicolo
public class Camion : IVeicolo {
    public void Avvia() {
        Console.WriteLine("Camion avviato.");
    }
    public void MostraTipo() {
        Console.WriteLine("Tipo: Camion");
    }
}
// 4. Creator: dichiara VeicoloFactory
public static class VeicoloFactory {
    public static IVeicolo CreaVeicolo(string tipo) {
        switch (tipo.ToLower()) {
            case "auto":
                return new Auto();
            case "moto":
                return new Moto();
            case "camion":
                return new Camion();
            default:
                Console.WriteLine("scelta non valida");
                return null;
        }
    }
}
//singleton : registraVeicolo
public sealed class RegistraVeicolo {
    private static RegistraVeicolo istanza;
    List<IVeicolo> veicoliregistrati = new List<IVeicolo>();
    private RegistraVeicolo() { }
    public static RegistraVeicolo Istanza {
        get {
            if (istanza == null)
                istanza = new RegistraVeicolo();
            return istanza;
        }
    }
    public void Registra(IVeicolo veicolo) {
        veicoliregistrati.Add(veicolo);
    }
    public void StampaTutti() {
        Console.WriteLine("\nVeicoli registrati:");
        foreach (var v in veicoliregistrati)
        {
            v.MostraTipo();
        }
    }
}

// programm
class Program {
    static void Main() {
        bool continua = true;
        while (continua) {
            Console.Write("Scegli Opzione: ");
            Console.Write("1 .crea veicolo ");
            Console.Write("2 .stampa tutti i veicoli ");
            Console.Write("3.esci ");
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta) {
                case 1:
                    Console.WriteLine("che veicolo vuoi creare?");
                    string input = Console.ReadLine();
                    IVeicolo v = VeicoloFactory.CreaVeicolo(input);
                    RegistraVeicolo.Istanza.Registra(v);
                    break;
                case 2:
                    RegistraVeicolo.Istanza.StampaTutti();
                    break;
                case 3:
                    continua = false;
                    break;
                default:
                    Console.WriteLine("scelat non valida");
                    break;
            }
        }
    }
}
