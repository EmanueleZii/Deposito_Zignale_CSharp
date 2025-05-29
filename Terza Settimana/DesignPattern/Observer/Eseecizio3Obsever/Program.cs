using System;
using System.Collections.Generic;
public interface IObserver {
    void NotificaCreazione(string nomeUtente);
}
public interface ISoggetto
{
    string nomeUtente { get; set; }
    void Register(IObserver subscriber);
    void Remove(IObserver subscriber);
}
public class Utente
{
    public string nome;

    public Utente(string _name)
    {
        nome = _name;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
//singleton
public class GestioneCreazioneUtente : ISoggetto
{
    private static GestioneCreazioneUtente _instance;
    private List<IObserver> _subscribers = new List<IObserver>();
    private string _nome_utente;
    private GestioneCreazioneUtente() { }
    public static GestioneCreazioneUtente Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GestioneCreazioneUtente();
            return _instance;
        }
    }
    public string nomeUtente
    {
        get => _nome_utente;
        set
        {
            _nome_utente = value;
            NotifyAll();
        }
    }
    public void Register(IObserver subscriber)
    {
        if (!_subscribers.Contains(subscriber))
            _subscribers.Add(subscriber);
    }
    public void Remove(IObserver subscriber)
    {
        _subscribers.Remove(subscriber);
    }
    private void NotifyAll()
    {
        foreach (var s in _subscribers)
            s.NotificaCreazione(_nome_utente);
    }
    private Utente CreaUtente(string nome)
    {
        return new Utente(nome);
    }
}

public static class UserFactory
{
    public static Utente Crea(string nome)
    {
        return new Utente(nome);
    }
}
public class ModuloLog : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"nome : {nomeUtente}");
    }
}
public class ModuloMarketing : IObserver
{
    public void NotificaCreazione(string nomeUtente)
    {
        Console.WriteLine($"nome : {nomeUtente}");
    }
}
// Programma principale
class Program
{
    static void Main()
    {
        var gestione = GestioneCreazioneUtente.Instance;
        IObserver moduloLog = new ModuloLog();
        IObserver moduloMark = new ModuloMarketing();

        gestione.Register(moduloLog);
        gestione.Register(moduloMark);
        bool continua = true;
        string nome = "";
        while (continua)
        {
            Console.WriteLine("Scegli dalle Opzioni\n 1 .Crea un utente \n 2 .esci");
            int Scelta = int.Parse(Console.ReadLine());
            if (Scelta == 1)
            {
                Console.WriteLine("Inserisci nome utente:");
                nome = Console.ReadLine();
                gestione.nomeUtente = nome;
            }
            if (Scelta == 2)
            {
                Console.Clear();
                continua = false;
            }
        }
    }
}
