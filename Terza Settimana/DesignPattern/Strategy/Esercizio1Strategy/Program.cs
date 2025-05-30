using System;
using System.Collections.Generic;
// 1.l'interfaccia comune per tutti gli algoritmi
public interface IStrategyOperazione {
    double Calcola(double a, double b);
}
// 2. ConcreteSomma: implementa la somma
public class ConcreteSomma : IStrategyOperazione {
    public double Calcola(double a, double b) {
        return a + b;
    }
}
// 3. ConcreteSottrazione: implementa la sottrazione
public class ConcreteSottrazione : IStrategyOperazione {
    public double Calcola(double a, double b) {
        return a - b;
    }
}
// 4. ConcreteMoltiplicazione: implementa la moltiplicazione
public class ConcreteMoltiplicazione : IStrategyOperazione
{
    public double Calcola(double a, double b)
    {
        return a * b;
    }
}
// 4. ConcreteDivisione: implementa la Divisione
public class ConcreteDivisione : IStrategyOperazione {
    public double Calcola(double a, double b) {
        return a / b;
    }
}
// 5. Context: utilizza una strategia per eseguire l'operazione
public class Calcolatrice {
    // Riferimento alla strategia corrente
    private  IStrategyOperazione _strategy;
    // Permette di cambiare strategia a runtime
    public void IpostaStrategiaOperazione(IStrategyOperazione strategy) {
        _strategy = strategy;
    }
    // Esegue l'algoritmo tramite la strategia corrente
    public void EseguiOperazione(double a, double b){
        if (_strategy == null) {
            Console.WriteLine("Nessuna calcolo impostata.");
            return;
        }
        double result = _strategy.Calcola(a, b);
        Console.WriteLine($"Risultato dell'operazione: {result}");
    }
}
// 6. Client: configura il contesto e usa diverse strategie
class Program {
    static void Main() {
        var calcolatrice = new Calcolatrice();

        while (true) {
            Console.WriteLine("\n--- Calcolatrice ---");
            Console.WriteLine("1. Somma");
            Console.WriteLine("2. Sottrazione");
            Console.WriteLine("3. Moltiplicazione");
            Console.WriteLine("4. Divisione");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'operazione: ");
            string scelta = Console.ReadLine();

            if (scelta == "0") break;

            Console.Write("Inserisci il primo numero: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Inserisci il secondo numero: ");
            double b = Convert.ToDouble(Console.ReadLine());

            switch (scelta) {
                case "1":
                    calcolatrice.IpostaStrategiaOperazione(new ConcreteSomma());
                    break;
                case "2":
                    calcolatrice.IpostaStrategiaOperazione(new ConcreteSottrazione());
                    break;
                case "3":
                    calcolatrice.IpostaStrategiaOperazione(new ConcreteMoltiplicazione());
                    break;
                case "4":
                    calcolatrice.IpostaStrategiaOperazione(new ConcreteDivisione());
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    continue;
            }

            calcolatrice.EseguiOperazione(a, b);
        }
    }
}
