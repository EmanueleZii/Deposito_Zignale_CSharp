using System;
using System.Collections.Generic;
public interface INewsSubscriber {
    void Update(string news);
}
public interface INewsAgency {
    string News { get; set; }
    void Register(INewsSubscriber subscriber);
    void Remove(INewsSubscriber subscriber);
}
//singleton
public sealed class NewsAgency : INewsAgency {
    private static NewsAgency _instance;
    private List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();
    private string _news;
    private NewsAgency() { }
    public static NewsAgency Instance {
        get {
            if (_instance == null)
                _instance = new NewsAgency();
            return _instance;
        }
    }
    public string News {
        get => _news;
        set {
            _news = value;
            NotifyAll();
        }
    }
    public void Register(INewsSubscriber subscriber) {
        if (!_subscribers.Contains(subscriber))
            _subscribers.Add(subscriber);
    }
    public void Remove(INewsSubscriber subscriber){
        _subscribers.Remove(subscriber);
    }
    private void NotifyAll() {
        foreach (var s in _subscribers)
            s.Update(_news);
    }
}
public class MobileApp : INewsSubscriber {
    public void Update(string news) {
        Console.WriteLine($"notifica {news}");
    }
}
public class EmailClient : INewsSubscriber {
    public void Update(string news) {
        Console.WriteLine($"notifica {news}");
    }
} 
// Programma principale
class Program {
    static void Main() {
        
        INewsAgency agency = NewsAgency.Instance;
        var mobile = new MobileApp();
        var email = new EmailClient();

        agency.Register(mobile);
        agency.Register(email);
        bool continua = true;
        while (continua) {
            Console.Write("Inserisci una news (vuoto per uscire): ");
            string news = Console.ReadLine();
            agency.News = news;
            continua = false;
        }
    }
}
