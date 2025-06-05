using System;

enum TipoTransazione
{
    Acquisto,
    Rimborso,
    Trasferimento
}

class Program
{
    static void Main(string[] args)
    {
        decimal importo = 100m;
        Console.WriteLine($"Commissione Acquisto: {CalcolaCommissione(importo, TipoTransazione.Acquisto)}");
        Console.WriteLine($"Commissione Rimborso: {CalcolaCommissione(importo, TipoTransazione.Rimborso)}");
        Console.WriteLine($"Commissione Trasferimento: {CalcolaCommissione(importo, TipoTransazione.Trasferimento)}");
    }

    static decimal CalcolaCommissione(decimal importo, TipoTransazione tipo)
    {
        switch (tipo)
        {
            case TipoTransazione.Acquisto:
                return importo * 0.02m; 
            case TipoTransazione.Rimborso:
                return importo * 0.01m; 
            case TipoTransazione.Trasferimento:
                return 2.5m; 
            default:
                return 0m;
        }
    }
}