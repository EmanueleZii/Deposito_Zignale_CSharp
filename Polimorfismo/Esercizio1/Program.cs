using System;
using System.Collections.Generic;
    class Veicolo
    {
        public string Targa { get; set; }
        private int riparazioni;
        public int Riparazioni
        {
            get { return riparazioni; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Il numero di riparazioni non può essere negativo.");
                    riparazioni = 0;
                }
                if (value >= 3)
                {
                    riparazioni = 3;
                }
                else
                {
                    riparazioni = value;
                }
            }
        }

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
    class Camion : Veicolo
    {
        public override void Ripara()
        {
            base.Ripara();
            Console.WriteLine("Controllo sospensione, freni rinforzati e carico del camion.");
        }
    }
class Program
{
    static void Main()
    {
        // Creazione di un oggetto di tipo Veicolo
        List<Veicolo> veicoli = new List<Veicolo>
                    {
                        new Auto(),
                        new Moto(),
                        new Furgone()
                    };
        // Impostazione della targa del veicolo
        Console.WriteLine("Benvenuto nel programma di controllo veicoli.");
        Console.WriteLine("Inserisci la targa del veicolo:");
        foreach (var veicolo in veicoli)
        {
            Console.Write("Targa: ");
            veicolo.Targa = Console.ReadLine();
        }
        // Impostazione del numero di riparazioni

        bool continua = true;
        Moto MotoRiparata = new Moto();
        MotoRiparata.Riparazioni = 0;
        Auto AutoRiparata = new Auto();
        AutoRiparata.Riparazioni = 0;
        Camion FurgoneRiparato = new Camion();
        FurgoneRiparato.Riparazioni = 0;
        int budget = 0;
        Console.WriteLine("Inserisci il budget per le riparazioni:");
        budget = int.Parse(Console.ReadLine());

        // Ciclo di controllo dei veicoli
        while (continua)
        {
            Menu();
            Console.WriteLine("Scegli un'opzione:");
            string scelta = Console.ReadLine();
            // Controllo del numero di riparazioni
            switch (scelta)
            {
                case "1":
                    veicoli[0].Ripara();
                    AutoRiparata.Riparazioni++;
                    
                    if (AutoRiparata.Riparazioni >= 3 )
                    {
                        Console.WriteLine("Il veicolo non può essere riparato.");
                        AutoRiparata.Riparazioni = 0;
                    }
                    else if (budget < 100)
                    {
                        Console.WriteLine("Il budget non è sufficiente per la riparazione.");
                    }
                    else
                    {
                        budget -= 100;
                        Console.WriteLine($"Il veicolo è stato riparato {AutoRiparata.Riparazioni} volte.");
                    }
                    break;
                case "2":
                    // Controllo del numero di riparazioni
                    veicoli[1].Ripara();
                    MotoRiparata.Riparazioni++;

                    if (MotoRiparata.Riparazioni >= 3)
                    {
                        Console.WriteLine("Il veicolo non può essere riparato.");
                        MotoRiparata.Riparazioni = 0;

                    }
                    else if (budget < 100)
                    {
                        Console.WriteLine("Il budget non è sufficiente per la riparazione.");
                    }
                    else
                    {
                        budget -= 100;
                        Console.WriteLine($"Il veicolo è stato riparato {MotoRiparata.Riparazioni} volte.");
                    }
                    
                    break;
                case "3":
                    veicoli[2].Ripara();
                    FurgoneRiparato.Riparazioni++;
                    if (veicoli[2].Riparazioni >= 3&& budget > 100)
                    {
                        Console.WriteLine("Il veicolo non può essere riparato.");
                        FurgoneRiparato.Riparazioni = 0;
                    }
                    else if (budget < 100)
                    {
                        Console.WriteLine("Il budget non è sufficiente per la riparazione.");
                    }
                    else
                    {
                        budget -= 100;
                        Console.WriteLine($"Il veicolo è stato riparato {FurgoneRiparato.Riparazioni} volte.");
                    }
                    break;
                case "4":
                    foreach (var veicolo in veicoli)
                    {
                        veicolo.Ripara();
                        if (AutoRiparata.Riparazioni >= 3)
                        {
                            Console.WriteLine("Il veicolo non può essere riparato.");
                            AutoRiparata.Riparazioni = 0;
                        }
                        else if (MotoRiparata.Riparazioni >= 3)
                        {
                            Console.WriteLine("Il veicolo non può essere riparato.");
                            MotoRiparata.Riparazioni = 0;
                        }
                        else if (FurgoneRiparato.Riparazioni >= 3)
                        {
                            Console.WriteLine("Il veicolo non può essere riparato.");
                            FurgoneRiparato.Riparazioni = 0;
                        }
                        else if (budget < 100)
                        {
                            Console.WriteLine("Il budget non è sufficiente per la riparazione.");
                        }
                        else
                        {
                            budget -= 300;
                            Console.WriteLine($"Il veicolo è stato riparato {veicolo.Riparazioni} volte.");
                        }

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
    public static void Menu()
    {
        Console.WriteLine("Benvenuto nel programma di controllo veicoli.");
        Console.WriteLine("1. Auto");
        Console.WriteLine("2. Moto");
        Console.WriteLine("3. Furgone");
        Console.WriteLine("4. Controlla tutti i veicoli");
        Console.WriteLine("5. Esci");
    }

} 