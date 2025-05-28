using System;

// 1. Iveicolo: definisce l'interfaccia del prodotto
public interface IVeicolo {
    void Avvia();
    void MostraTipo();
}

// 2. Auto: implementa IProduct
public class Auto : IVeicolo {
    public void Avvia(){
        Console.WriteLine("Avvia Una Auto");
    }
    public void MostraTipo() {
        Console.WriteLine("Mostra Auto");
    }
}

// 3. Moto: un altro prodotto concreto
public class Moto : IVeicolo {
    public void Avvia() {
        Console.WriteLine("Avvia Moto");
    }
    public void MostraTipo() {
        Console.WriteLine("Mostra Moto");
    }
}

public class Camion : IVeicolo {
    public void Avvia() {
        Console.WriteLine("Avvia Moto");
    }
    public void MostraTipo(){
        Console.WriteLine("Mostra Moto");
    }
}
// 4. Creator: dichiara VeicoloFactory
public static class VeicoloFactory {
    public static IVeicolo CreaVeicolo(string tipo) {
        switch (tipo.ToLower()) {
            case "auto":
                return new Auto();
                break;
            case "moto":
                return new Moto();
                break;
            case "camion":
                return new Auto();
                break;
            default:
                Console.Write("scelta non valida");
                return null;
                break;
        }
    }
}
class Program {
    static void Main() {
        Console.WriteLine("Che veicolo vuoi creare");
        string input = Console.ReadLine();
        IVeicolo veicolo = VeicoloFactory.CreaVeicolo(input);
        
        if (veicolo != null){
            Console.WriteLine("Error:  da un valore valido");
        }

    }
}