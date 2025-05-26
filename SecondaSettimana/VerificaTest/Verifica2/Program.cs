using System;

public class ContoCorrente
{
    private decimal saldo;
    private int numeroOperazione;
    public decimal Saldo
    {
        get
        {
            return saldo;
        }
        set
        {
            saldo = value;
        }

    }

    public int NumeroOperazione
    {
        get
        {
            return numeroOperazione;
        }
    }
    public decimal Versa(decimal importo)
    {
        return saldo += importo;
    }
    public decimal Preleva(decimal prelievo)
    {
        return saldo -= prelievo;
    }
}


public class Program
{
    public void Main()
    {
        
    }
}