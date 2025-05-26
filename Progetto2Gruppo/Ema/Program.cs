using System;
public class Dipendente {
    private string nome;
    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }
    private int eta;
    public int Eta
    {
        get { return eta; }
        set {
            if (value >= 18) {
                eta = value;
            }
            else {
                Console.WriteLine("Età non consentita");
            }
        }
    }
    public virtual void EseguiCompito()
    {
        Console.WriteLine("Compito generico del dipendente");
    }
    public Dipendente(string _nome, int _eta)
    {
        nome = _nome;
        eta = _eta;
    }
}

//Creazione classe derivata
public class Autista : Dipendente
{
    private string patente;
    public string Patente
    {
        get { return patente; }
        set { patente = value; }
    }
    //Costruttore che dichiara i valori della derivata
    public Autista(string nome, int eta, string patente) : base(nome, eta)
    {
        Patente = patente;
    }
    //Sovrascrittura del metodo di stampa
    public override void EseguiCompito()
    {
        Console.WriteLine($"{Nome} sta guidando il veicolo con la patente {Patente}");
    }
}
//classe derivata 
public class Meccanico : Dipendente
{
    //attributi privati
    private string specializzazione;

    //proprietà pubbliche
    public string Specializzazione
    {
        get { return specializzazione; }
        set { specializzazione = value; }
    }

    //costruttore
    public Meccanico(string _nome, int _eta, string _specializzazione) : base(_nome, _eta)
    {
        Specializzazione = _specializzazione;
    }
    public override void EseguiCompito()
    {
        Console.WriteLine($"Ripara mezzi specializzati in: {Specializzazione}.");
    }
}
//classe figlia del Dipendente
public class OperatoreCentrale : Dipendente
{
    //proprieta privata
    private string Turno = "";
    //proprieta pubblica con get set
    public string turno
    {
        get
        {
            return Turno;
        }
        set
        {
            if (turno == "Giorno" || turno == "giorno")
            {
                Turno = "Giorno";
            }
            if (turno == "Notte" || turno == "notte")
            {
                Turno = "Notte";
            }
        }
    }
    //classe ereditata dalla classe madre
    public override void EseguiCompito()
    {
        base.EseguiCompito();
        Console.WriteLine($"{Turno}");
    }
    public OperatoreCentrale(string nome,int eta, string _turno ) : base (nome, eta)
    {
        turno = _turno; 
    }
}

public class Programs
{
    public static void Main()
    { 
        
    }
}