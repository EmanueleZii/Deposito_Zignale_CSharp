using System;
public enum GiorniDellaSettimana
    {
        lunedi,
        martedi,
        mercoledi,
        giovedi,
        venerdi,
        sabato,
        domenica
    }
public class Programs
{

    public void Main()
    {
        Console.WriteLine("Seleziona un giorno della settimana");
        Console.WriteLine("1.lunedi\n 2. Martedi \n 3.Mercoledi \n 4.Giovedi \n .5 venerdi\n 6.sabato \n .7 domenica");

        string scelta = Console.ReadLine().ToLower();

        if (scelta == GiorniDellaSettimana.lunedi.ToString().ToLower())
            Console.WriteLine("si ricomincia");
        if (scelta == GiorniDellaSettimana.martedi.ToString().ToLower())
            Console.WriteLine("stiamo ingranando");
        if (scelta == GiorniDellaSettimana.mercoledi.ToString().ToLower())
            Console.WriteLine("Work Work!");
        if (scelta == GiorniDellaSettimana.giovedi.ToString().ToLower())
            Console.WriteLine("siamo a meta settimana");
        if (scelta == GiorniDellaSettimana.venerdi.ToString().ToLower())
            Console.WriteLine("dai dopo oggi hai due giorni liberi");
        if (scelta == GiorniDellaSettimana.sabato.ToString().ToLower())
            Console.WriteLine("vado a fare la spesa");
        if (scelta == GiorniDellaSettimana.domenica.ToString().ToLower())
            Console.WriteLine("Si nerda a monster hunter!!!");

    }
}

