using System;



    class Veicolo
    {
        string Targa;
        public virtual void Ripara()
        { 
                Console.WriteLine("Il veicolo viene controllato.");
        }
    }

    class Auto : Veicolo
    {
        public override void Ripara()
        {
            base.Ripara();
            Console.WriteLine("Controllo olio, freni e motore dell' auto.");
        }
    }
    

    class Moto : Veicolo
    {
        public override void Ripara()
        {
            base.Ripara();
            Console.WriteLine("Controllo catena, freni e motore della moto.");
        }
    }
    class Furgone : Veicolo
    {
        public override void Ripara()
        {
            base.Ripara();
            Console.WriteLine("Controllo sospensione, freni rinforzati e carico del camion.");
        }
    }
    

    class Program
    {
    static void Main(string[] args)
    {
        List<Veicolo> veicoli = new List<Veicolo>
            {
                new Auto(),
                new Moto(),
                new Furgone()
            };

        foreach (var veicolo in veicoli)
        {
            veicolo.Ripara();
        }
        Console.WriteLine("Tutti i veicoli sono stati controllati.");
        Console.WriteLine("Premi un tasto per uscire.");
        Console.ReadKey();
    }
}