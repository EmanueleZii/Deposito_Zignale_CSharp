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
        Console.Write("Con Latte");
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
        Console.Write("Con Cioccolato");
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
        Console.Write("Con Panna");
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
        Menu();
    }

    public static void Menu() {
        bool continua = true;
        int sceltacontimento = 0;
        while (continua)
        {
            Console.WriteLine("Scegli la bevanda");
            Console.WriteLine("1. Caffe");
            Console.WriteLine("2. Te");
            Console.WriteLine("3. Esci");
            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Hai scelto il caffe");
                    Console.WriteLine("Vuoi qualcosa nel Caffe?\n 0.solocaffe \n 1. latte\n 2. con cioccolato\n 3.panna");
                    sceltacontimento = int.Parse(Console.ReadLine());
                    if (sceltacontimento == 0)
                    {
                        IBevanda bevanda1 = new Caffe();
                        bevanda1.Descrizione();
                        bevanda1.Costo();
                    }
                    if (sceltacontimento == 1)
                    {
                        IBevanda bevanda2 = new ConcreteConLatte(new Caffe());
                        bevanda2.Descrizione();
                        bevanda2.Costo();
                    }
                    if (sceltacontimento == 2)
                    {
                        IBevanda bevanda3 = new ConcreteConCioccolato(new Caffe());
                        bevanda3.Descrizione();
                        bevanda3.Costo();
                    }
                    if (sceltacontimento == 3)
                    {
                        IBevanda bevanda3 = new ConcreteConPanna(new Caffe());
                        bevanda3.Descrizione();
                        bevanda3.Costo();
                    }
                    break;
                case 2:
                    Console.WriteLine("Hai scelto il te");
                    Console.WriteLine("Vuoi qualcosa nel Caffe?\n0.solocaffe \n1. latte \n2. con cioccolato \n 3.panna");
                    sceltacontimento = int.Parse(Console.ReadLine());
                    if (sceltacontimento == 0)
                    {
                        IBevanda bevanda1 = new Te();
                        bevanda1.Descrizione();
                        bevanda1.Costo();
                    }
                    if (sceltacontimento == 1)
                    {
                        IBevanda bevanda2 = new ConcreteConLatte(new Te());
                        bevanda2.Descrizione();
                        bevanda2.Costo();
                    }
                    if (sceltacontimento == 2)
                    {
                        IBevanda bevanda3 = new ConcreteConCioccolato(new Te());
                        bevanda3.Descrizione();
                        bevanda3.Costo();
                    }
                    if (sceltacontimento == 3)
                    {
                        IBevanda bevanda3 = new ConcreteConPanna(new Te());
                        bevanda3.Descrizione();
                        bevanda3.Costo();
                    }
                    break;
                case 3:
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }

        }
    }
}