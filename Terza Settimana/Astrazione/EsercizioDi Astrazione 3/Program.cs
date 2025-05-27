using System;
using System.Collections.Generic;

public interface IPagamento
{
    public void EseguiPagamento(decimal importo);
    public void MostraMetodo();
}
public class PagamentoCarta : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} effettuato con carta.");
    }
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo di pagamento: Carta di credito/debito.");
    }
}
public class PagamentoContanti : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} effettuato in contanti.");
    }
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo di pagamento: Contanti.");
    }
}

public class PagamentoPaypal : IPagamento
{
    public void EseguiPagamento(decimal importo)
    {
        Console.WriteLine($"Pagamento di {importo} effettuato con Paypal.");
    }
    public void MostraMetodo()
    {
        Console.WriteLine("Metodo di pagamento: Paypal.");
    }
}
public class Program
{
    public static void Main()
    {
        List<PagamentoCarta> pagamentiCarta = new List<PagamentoCarta>();
        List<PagamentoContanti> pagamentiContanti = new List<PagamentoContanti>();
        List<PagamentoPaypal> pagamentiPaypal = new List<PagamentoPaypal>();
        bool esegui = true;
        string modelloComputer = "";
        string modelloStampante = "";
        string modelloDaAccendere = "";
        string modelloDaSpegnere = "";
        PagamentoCarta pagamentoCarta = null;
        PagamentoContanti pagamentoContanti = null;
        PagamentoPaypal pagamentoPaypal = null;
        Console.WriteLine("Gestione Pagamenti");
        decimal importo = 0;
        Console.WriteLine("Inserisci il budget:");
        importo = decimal.Parse(Console.ReadLine());
        if (importo <= 0)
        {
            Console.WriteLine("Importo non valido. Il programma si chiuderà.");
            return;
        }
        Console.WriteLine("scegli l operazione da eseguire:");
        while (esegui) {
            Menu();
            string scelta = Console.ReadLine();
            switch (scelta) {
                case "1":
                    Console.WriteLine("Paga Con Carta:");
                    modelloComputer = Console.ReadLine();
                    pagamentiCarta.Add(pagamentoCarta = new PagamentoCarta());
                    break;
                case "2":
                    Console.WriteLine("Paga Con Contanti:");
                    modelloStampante = Console.ReadLine();
                    pagamentiContanti.Add(pagamentoContanti = new PagamentoContanti());
                    break;
                  case "3":
                    Console.WriteLine("Paga Con Paypal:");
                    importo = decimal.Parse(Console.ReadLine());
                    pagamentiPaypal.Add(pagamentoPaypal = new PagamentoPaypal());
                    break;
                case "4":
                    
                    break;
                case "5":
                    esegui = false;
                    break;
                default:
                    Console.WriteLine("Opzione non valida, riprova.");
                    break;
            }
        }
    }
    public static void Menu()
    {
        Console.WriteLine("Scegli un'opzione:");
        Console.WriteLine("1. Paga con Carta");
        Console.WriteLine("2. Paga con Contanti");
        Console.WriteLine("3. Mostra tutti i Pagamenti");
        Console.WriteLine("4. Esci");
    }
    public static void StampaTuttiIPagamenti(List<PagamentoCarta> pagacarta,List<PagamentoContanti> pagacontanti,List<PagamentoPaypal> pagapaypal)
    {
        Console.WriteLine("Pagamenti con Carta:");
        foreach (var pagamento in pagacarta)
        {
            pagamento.MostraMetodo();
        }
        Console.WriteLine("Pagamenti in Contanti:");
        foreach (var pagamento in pagacontanti)
        {
            pagamento.MostraMetodo();
        }
        Console.WriteLine("Pagamenti con Paypal:");
        foreach (var pagamento in pagapaypal)
        {
            pagamento.MostraMetodo();
        }
    }
    public static void EseguiPagamento(List<IPagamento> paga, decimal importo)
    {
        foreach (var pagamento in paga)
        {
            pagamento.EseguiPagamento(importo);
        }
    }
}