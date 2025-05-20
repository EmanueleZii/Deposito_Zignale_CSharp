using System;
/*19 maggio 2025*/
public class Cane
{
    public string Name = "";
    public int Age = 0;
    public void Abbaia() {
        Console.WriteLine($"{Name} dice bau");
    }
}

public class Persona
{ 
    public string Name = "";
    public int Age = 0;
    public Persona(string name, int age){
        Name = name;
        Age = age;
    }
    public void Presentati(){
        Console.WriteLine($"Ciao, mi chiamo {Name} e ho {Age} anni.");
    }
}

public class Programma
{
    public static void Main(string[] args) {
        // Creazione dei oggetto 
        Cane bau = new Cane();
        Persona mario = new Persona("Mario", 30);
        // Assegnazione dei valori alle proprietà
        bau.Name = "Fido";
        bau.Age = 3;
        // Stampa dei valori delle proprietà
        bau.Abbaia();
        mario.Presentati();
    }
}
