using System;
/* 19 maggio 2025 */
public class Operazioni
{
    // Metodo principale
    public static void Main(string[] args) {
        Menu();
    }

    static void Menu() {
        Console.WriteLine("Benvenuto nel programma di calcolo!");
        Console.WriteLine("Inserisci il primo numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Inserisci il secondo numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Scegli l'operazione da eseguire:");
        Console.WriteLine("1. Somma");
        Console.WriteLine("2. Moltiplicazione");
        Console.WriteLine("3. Divisione");
        int scelta = Convert.ToInt32(Console.ReadLine());
        switch (scelta) {
            case 1:
                Somma(num1, num2);
                break;
            case 2:
                Moltiplicazione(num1, num2);
                break;
            case 3:
                Divisione(num1, num2);
                break;
            default:
                Console.WriteLine("Operazione non valida.");
                break;
        }
    }

    static void Somma(int a, int b) {
        int somma = a + b;
        StampaRisultato("Somma", somma);
    }

    static void Moltiplicazione(int a, int b) {
        int moltiplicazione = a * b;
        StampaRisultato("Moltiplicazione", moltiplicazione);
    }
    
    static void Divisione(int a, int b) {
        try
        {
            int divisione = a / b;
            StampaRisultato("Divisione", divisione);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Errore: Divisione per zero non consentita.");
            
        }
    }
    // Metodo per stampare il risultato
    static void StampaRisultato(string operazione, int risultato)
    {
        Console.WriteLine($"Il risultato dell'operazione {operazione} è: {risultato}");
    }

}

