﻿using System;
using System.Collections.Generic;

public class Soldato {
    private string nome;
    private string grado;
    private int annidiservizio;
    public string Nome { get; set; }
    public string Grado {get; set;}
    public int AnniDiServizio { get; set; }
    public Soldato(string nome, string grado, int annidiservizio){
        Nome = nome;
        Grado = grado;
        AnniDiServizio = annidiservizio;
    }
    public virtual void Descrizione() {
        Console.WriteLine($"Nome: {Nome}, Grado: {Grado}, Anni di Servizio: {AnniDiServizio}");
    }
}
public class Fante : Soldato {
    private string arma;
    public string Arma { get; set; }
    public Fante(string nome, string grado, int annidiservizio, string arma) 
    : base(nome, grado, annidiservizio)
    {
        Arma = arma;
    }
    public override void Descrizione() {
        base.Descrizione();
        Console.WriteLine($"Arma: {Arma}");
    }
}
public class Artigliere : Soldato {
    private int calibro;
    public int Calibro { get; set; }
    public Artigliere(string nome, string grado, int annidiservizio, int cali) 
    : base(nome, grado, annidiservizio)
    {
        this.Calibro = cali;
    }
    public override void Descrizione() {
        base.Descrizione();
        Console.WriteLine($"Specializzazione: {calibro}");
    }
}
public class Program {

    // Main method
    // Entry point of the program
    public static void Main() {

        List<Soldato> soldati = new List<Soldato>();

        Fante fante = null;
        Artigliere artigliere = null;

        string nome = "";
        string grado = "";
        string arma = "";
        int annidiservizio = 0;
        int calibro = 0;
        bool continua = true;
        int scelta = 0;

        Console.WriteLine("Benvenuto nel programma di gestione soldati.");

        while (continua) {
            Menu();
            scelta = int.Parse(Console.ReadLine());
            switch (scelta) {
                case 1:
                    AggiungiFante(fante, soldati);
                    Console.Clear();
                    break;
                case 2:
                    AggiungiArtigliere(artigliere, soldati);
                    Console.Clear();
                    break;
                case 3:
                    StampaSoldati(soldati);
                    break;
                default:
                    continua = false;
                    Console.Clear();
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }
    public static void StampaSoldati(List<Soldato> soldati) {
        foreach (var soldato in soldati) {
            soldato.Descrizione();
        }
    }
    public static void AggiungiArtigliere(Artigliere artigliere, List<Soldato> soldati) {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Grado: ");
        string grado = Console.ReadLine();
        Console.Write("Anni di Servizio: ");
        int annidiservizio = int.Parse(Console.ReadLine());
        Console.Write("Calibro: ");
        int calibro = int.Parse(Console.ReadLine());
        artigliere = new Artigliere(nome, grado, annidiservizio, calibro);
        soldati.Add(artigliere);
    }
    public static void AggiungiFante(Fante fante, List<Soldato> soldati) {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Grado: ");
        string grado = Console.ReadLine();
        Console.Write("Anni di Servizio: ");
        int annidiservizio = int.Parse(Console.ReadLine());
        Console.Write("Arma: ");
        string arma = Console.ReadLine();
        fante = new Fante(nome, grado, annidiservizio, arma);
        soldati.Add(fante);
    }
    public static void Menu() {
        Console.Write("Scegli un'opzione: ");
        Console.WriteLine("1. Aggiungi Fante");
        Console.WriteLine("2. Aggiungi Artigliere");
        Console.WriteLine("3. Visualizza Soldati");
        Console.WriteLine("4. Esci");
    }
}