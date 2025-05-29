using System;
using System.Collections.Generic;

// 1. Observer: interfaccia che definisce il metodo di notifica
public interface IObserver
{
    void Update(string messaggio);
}

// 2. Subject: interfaccia che permette di aggiungere/rimuovere observer e notificare
public interface ISoggetto
{
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

    public void Rimuovi(IObserver observer){
        _observers.Remove(observer);
    }

    public void Notifica(string messaggio) {
        foreach (var observer in _observers) {
            observer.Update(messaggio);
        }
    }
}

// 4. ConcreteObserver: implementa la logica di reazione alla notifica
public class DisplayConsole : IObserver
{
    private readonly string _name;

    public DisplayConsole(string name)
    {
        _name = name;
    }

    public void Update(string messaggio)
    {
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

    public void Update(string messaggio) {
        Console.WriteLine($"{_name} ha ricevuto aggiornamento meteo: {messaggio}");
    }
}

// 5. Client: crea il subject e alcuni observer, e modella cambi di stato
class Program
{
    static void Main()
    {
        var centro = new CentroMeteo();

        var osservatore1 = new DisplayConsole("Display Sala Controllo");
        var osservatore2 = new DisplayMobile("App Mobile");

        centro.Registra(osservatore1);
        centro.Registra(osservatore2);

        centro.State = "Soleggiato con 25°C";
        centro.State = "Temporale in arrivo";

        centro.Rimuovi(osservatore1);
        centro.State = "Nevicata prevista domani";
    }
}