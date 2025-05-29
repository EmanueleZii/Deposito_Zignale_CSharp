using System;

// 1. Component: definisce l'interfaccia dell'oggetto
public interface IBevanda
{
    void Descrizione();
    double Costo();
}
// 2. ConcreteComponent: oggetto base senza decorazioni
public class Caffe : IBevanda
{
    double costo = 1.00;
    public void Descrizione()
    {
        Console.WriteLine("Sono un Caffe");
    }
    public double Costo()
    {
        return costo;
    }
}
public class Te : IBevanda
{
    double costo = 2.00;
    public void Descrizione()
    {
        Console.WriteLine("Sono un te");
    }
    public double Costo()
    {
        return costo;
    }
}
// 3. Decorator: classe astratta che implementa IComponent 
//    e incapsula un IComponent interno
public abstract class DecoratoratoreBevanda : IBevanda
{
    // Riferimento al componente "decorato"
    protected IBevanda _bevanda;

    // Costruttore: richiede un componente da decorare
    protected DecoratoratoreBevanda(IBevanda component)
    {
        _bevanda = component;
    }
    public virtual void Descrizione()
    {
        _bevanda.Descrizione();
    }

    public virtual double Costo()
    {
        return _bevanda.Costo();
    }
    // Delegazione dell'operazione al componente interno
    public override string ToString()
    {
        return base.ToString();
    }
}
// 4. ConcreteDecoratorA: aggiunge comportamento prima e dopo la chiamata
public class ConcreteConLatte :DecoratoratoreBevanda
{
    IBevanda bevanda;
    public ConcreteConLatte(IBevanda bevanda) : base(bevanda) {}

    public override void Descrizione()
    {
        base.Descrizione();
    }
    public override double Costo()
    {
        return base.Costo() + 0.5;
    }
    
}

// 5. ConcreteDecoratorB: aggiunge un altro comportamento distinto
public class ConcreteConCioccolato :DecoratoratoreBevanda
{
    IBevanda bevanda;
    public ConcreteConCioccolato(IBevanda bevanda) : base(bevanda) {}

    public override void Descrizione()
    {
        base.Descrizione();
    }
    public override double Costo()
    {
        return base.Costo() + 0.5;
    }
    
}
public class ConcreteConPanna :DecoratoratoreBevanda
{
    IBevanda bevanda;
    public ConcreteConPanna(IBevanda bevanda) : base(bevanda) {}

    public override void Descrizione()
    {
        base.Descrizione();
    }
    public override double Costo()
    {
        return base.Costo() + 0.5;
    }
    
}
// Esempio di utilizzo (Client)
class Program
{
    static void Main()
    {
        Console.WriteLine("Ordine 1: Caffè con Latte e Cioccolato");
        IBevanda bevanda1 = new ConcreteConCioccolato(new ConcreteConLatte(new Caffe()));
        bevanda1.Descrizione();
        Console.WriteLine("Costo: €" + bevanda1.Costo());

        Console.WriteLine("\nOrdine 2: Tè con Panna");
        IBevanda bevanda2 = new ConcreteConPanna(new Te());
        bevanda2.Descrizione();
        Console.WriteLine("Costo: €" + bevanda2.Costo());
    }
}