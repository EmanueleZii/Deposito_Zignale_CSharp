using System;
using System.Collections.Generic;
    class Veicolo
    {
        public string Targa { get; set; }
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
    class Program {
        
        static void Main() {
            List<Veicolo> veicoli = new List<Veicolo>
                    {
                        new Auto(),
                        new Moto(),
                        new Furgone()
                    };
            Console.WriteLine("Benvenuto nel programma di controllo veicoli.");
            Console.WriteLine("Inserisci la targa del veicolo:");
            foreach (var veicolo in veicoli)
            {
                Console.Write("Targa: ");
                veicolo.Targa = Console.ReadLine();
            }
            bool continua = true;

            while (continua)
            {
                Console.WriteLine("Scegli un veicolo da controllare:");
                Console.WriteLine("1. Auto");
                Console.WriteLine("2. Moto");
                Console.WriteLine("3. Furgone");
                Console.WriteLine("4. Controlla tutti i veicoli");
                Console.WriteLine("5. Esci");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        veicoli[0].Ripara();
                        break;
                    case "2":
                        veicoli[1].Ripara();
                        break;
                    case "3":
                        veicoli[2].Ripara();
                        break;
                    case "4":
                        foreach (var veicolo in veicoli)
                        {
                            veicolo.Ripara();
                        }
                        Console.WriteLine("Tutti i veicoli sono stati controllati.");
                        break;
                    case "5":
                        continua = false;
                        Console.WriteLine("Uscita dal programma.");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
}