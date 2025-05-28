using System;
using System.Collections.Generic;

//Singleton ConfigurazioneSistema
public sealed class ConfigurazioneSistema {
    //Instanza vuota del ConfigurazioneSistema
    private static ConfigurazioneSistema instance;
    //Lista di log
    Dictionary<string, string> configurazioni = new Dictionary<string, string>();
    //costruttore vuoto privato
    private ConfigurazioneSistema() { }
    // la proprieta con il get per verificare se l instanza è null
    public static ConfigurazioneSistema Instance {
        get {
            if (instance == null)
                instance = new ConfigurazioneSistema();

            return instance;
        }
    }
    public void Imposta(string chiave, string valore) {
        Console.WriteLine($"chiave:{chiave} e {valore}");
        configurazioni.Add(chiave, valore);
    }
    public void Leggi(string chiave) {

        if (configurazioni.ContainsKey(chiave)) {
            string valore = configurazioni[chiave];
            Console.WriteLine($"Chiave: {chiave} → Valore: {valore}");
        }
        else {
            Console.WriteLine("Errore: Chiave non trovata.");
        }
    }
    //metodo che stampa tutti i log aggiunti alla lista 
    public void StampaTutteConfigurazioni()
    {
        Console.WriteLine("--- Configurazioni Memorizzate ---");
        foreach (var conf in configurazioni)
        {
            Console.WriteLine(conf);
        }
    }
}

public class Programs {
    public static void Main()
    {
        //instanze di ConfigurazioneSistema 
        //ConfigurazioneSistema conf1 = ConfigurazioneSistema.Instance;
        Console.WriteLine("Che Modulo di Sistema preferisci Modulo A o Modulo b");
        Console.WriteLine("1. Modulo A");
        Console.WriteLine("2. Modulo B");
        int modulo = int.Parse(Console.ReadLine());
        if (modulo == 1) {
            Console.WriteLine("Benvenuto nel Modulo A");
            MenuOpzioni();
        }
        if (modulo == 2) {
            Console.WriteLine("Benvenuto nel Modulo B");
            MenuOpzioni();
        } 

    }
    public static void MenuOpzioni() { 
        bool continua = true;

        while (continua)
        {
            //menu
            Console.WriteLine("Scegli operazione");
            Console.WriteLine("1. Stampa Tutte Configurazione");
            Console.WriteLine("2. Aggiungi una Configurazione");
            Console.WriteLine("3. Leggi Una Chiave");
            Console.WriteLine("4. Esci");

            int scelta = int.Parse(Console.ReadLine());

            string chiave = "";
            string valore = "";

            switch (scelta) {
                case 1:
                    ConfigurazioneSistema.Instance.StampaTutteConfigurazioni();
                    break;
                case 2:
                    Console.WriteLine("Crea una Configurazione");
                    Console.WriteLine("Inserisci una chiave");
                    chiave = Console.ReadLine();
                    Console.WriteLine("Inserisci un valore");
                    valore = Console.ReadLine();
                    ConfigurazioneSistema.Instance.Imposta(chiave, valore);
                    break;
                case 3:
                    Console.WriteLine("Leggi una Chiave");
                    Console.WriteLine("inserisci la chiave che vuoi trovare");
                    chiave = Console.ReadLine();
                    ConfigurazioneSistema.Instance.Leggi(chiave);
                    break;
                case 4:
                    continua = false;
                    break;
                default:
                    Console.WriteLine("scelta non valida");
                    break;
            }
        }
    }
}