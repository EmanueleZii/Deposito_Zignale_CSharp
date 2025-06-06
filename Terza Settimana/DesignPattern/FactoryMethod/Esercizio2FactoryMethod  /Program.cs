﻿using System;
// Design Pattern Factory Method

// 1. Ishape: definisce l'interfaccia del prodotto
public interface IShape {
    void Draw();
}
// 2. Cicle: implementa IProduct
public class Circle : IShape {
    public void Draw() {
        Console.WriteLine("Circle creato");
    }
}
// 3. Square: un altro prodotto concreto
public class Square : IShape {
    public void Draw() {
        Console.WriteLine("Square creato");
    }
}
public abstract class ShapeCreator {
    public abstract IShape CreateShape(string type);
}
// 4. Creator: dichiara ConcreteShapeCreator
public class ConcreteShapeCreator : ShapeCreator {
    public override IShape CreateShape(string tipo) {
        switch (tipo.ToLower()) {
            case "cerchio":
                return new Circle();
            case "quadrato":
                return new Square();
            default:
                Console.Write("scelta non valida");
                return null;
        }
    }
}
class Program {
    static void Main() {

        Console.WriteLine("Quale Forma vuoi disegnare");
        string input = Console.ReadLine();
        ShapeCreator create = new ConcreteShapeCreator();

        IShape disegna = create.CreateShape(input);
        disegna.Draw();
    }
}
