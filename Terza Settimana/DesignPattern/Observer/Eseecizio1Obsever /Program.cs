using System;
using System.Collections.Generic;

// 1. Observer: interfaccia che definisce il metodo di notifica
public interface IObserver {
    void Update(string messaggio);
}
// 2. Subject: interfaccia che permette di aggiungere/rimuovere observer e notificare
public interface ISoggetto {
    void Registra(IObserver observer);
    void Rimuovi(IObserver observer);
    void Notifica(string messaggio);
}
// 3. ConcreteSubject: implementa ISoggetto e mantiene lo stato osservato
public class CentroMeteo : ISoggetto
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private string _state;
    public string State {
        get => _state;
        set {
            _state = value;
            Notifica(_state);
        }
    }
    public void Registra(IObserver observer) {
        _observers.Add(observer);
    }
    public void Rimuovi(IObserver observer) {
        _observers.Remove(observer);
    }
    // Versione richiesta dall'interfaccia
    public void Notifica(string messaggio)
    {
        foreach (var observer in _observers)
        {
            observer.Update(messaggio);
        }
    }

    public void Notifica(string messaggio, Type targetType = null) {
        foreach (var observer in _observers) {
            if (targetType == null || observer.GetType() == targetType) {
                observer.Update(messaggio);
            }
        }
    }
    public void AggiornaMeteo(string dati, Type targetType = null) {
        Console.WriteLine("Aggiornamento meteo: " + dati);
        Notifica(dati, targetType);
    }
}
// 4. ConcreteObserver: implementa la logica di reazione alla notifica
public class DisplayConsole : IObserver {
    private readonly string _name;
    public DisplayConsole(string name) {
        _name = name;
    }
    public void Update(string messaggio) {
        Console.WriteLine($"{_name} ha ricevuto aggiornamento meteo: {messaggio}");
    }
}
public class DisplayMobile : IObserver
{
    private readonly string _name;
    public DisplayMobile(string name)
    {
        _name = name;
    }
    public void Update(string messaggio)
    {
        Console.WriteLine($"{_name} ha ricevuto aggiornamento meteo: {messaggio}");
    }
}
public class DisplayPC : IObserver {
    private readonly string _name;
    public DisplayPC(string name) {
        _name = name;
    }
    public void Update(string messaggio) {
        Console.WriteLine($"{_name} ha ricevuto aggiornamento meteo: {messaggio}");
    }
}
// 5. Client: crea il subject e alcuni observer, e modella cambi di stato
class Program {
    static void Main() {
        var centro = new CentroMeteo();
        bool continua = true;
        while (continua) {
            Console.WriteLine("\n1. Inserisci aggiornamento meteo\n0. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();
            switch (scelta) {
                case "1":
                    Console.Write("Inserisci nuove condizioni meteo: ");
                    string dati = Console.ReadLine();
                    centro.AggiornaMeteo(dati);
                    Console.WriteLine("Scegli dove notificare?");
                    Console.WriteLine("1. mobile");
                    Console.WriteLine("2. Console");
                    Console.WriteLine("3. PC");
                    Type tipo = null;
                    int scelta2 = int.Parse(Console.ReadLine());
                    if (scelta2 == 1)
                        tipo = typeof(DisplayMobile);
                    if (scelta2 == 2)
                        tipo = typeof(DisplayConsole);
                    if (scelta2 == 3)
                        tipo = typeof(DisplayPC);
                    break;
                case "0":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        /* centro.State = "Soleggiato con 25°C";
        centro.State = "Temporale in arrivo";
        centro.Rimuovi(osservatore1);
        centro.State = "Nevicata prevista domani";*/
    }
}