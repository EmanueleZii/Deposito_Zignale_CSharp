using System;

public class Program {
    
    public static void Main(string[] args)
    {

        Punto p1 = new Punto { X = 1, Y = 2 };
        Punto p2 = new Punto { X = 1, Y = 2 };

        Console.WriteLine(p1.Equals(p2)); // True
        Console.WriteLine(p1 == p2);

        Prodotto p3 = new Prodotto { Nome = "Pasta", Prezzo = 1.5 };
        Prodotto p4 = new Prodotto { Nome = "Pasta", Prezzo = 1.5 };
        Console.WriteLine(p3.GetHashCode()); // Hash code of p3
    }
}

//GetHashCode
public class Prodotto {
    public string Nome;
    public double Prezzo;

    public override int GetHashCode(){
        return Nome.GetHashCode() ^ Prezzo.GetHashCode();
    }
}

//Equals
public class Punto {
    public int X;
    public int Y;

    public override bool Equals(object obj){
        if (obj is Punto other) {
            return X == other.X && Y == other.Y;
        }
        return false;
    }
}
