using System;

class Program {

    static void Main(string[] args) {

        bool isLoged = false;
        int tentativi = 1;
        const int MaxTentativi = 3;

        do {
            Console.WriteLine("Inserisci la tua password:");
            string password = Console.ReadLine();

            Console.WriteLine("Inserisci il tuo nickname:");

            string nickname = Console.ReadLine();
            Console.WriteLine("Inserisci la tua eta:");
            int eta = Convert.ToInt32(Console.ReadLine());

            Utente utente = new Utente(password, nickname, eta);

            if (utente.Password == "123" && utente.Nickname == "ema" && utente.eta == 32 && tentativi < MaxTentativi) {

                Console.WriteLine($"Benvenuto {utente.Nickname}!");
                Console.WriteLine($"Hai {utente.eta} anni.");
                Console.WriteLine("Login effettuato con successo!");

                isLoged = true;

                MenuCalc();

                tentativi++;

                if (tentativi < MaxTentativi) {
                    Console.WriteLine("Vuoi continuare? (s/n)");
                    string risposta = Console.ReadLine();
                    if (risposta.ToLower() != "s") {
                        isLoged = false;
                        break;
                    }
                    else {
                        isLoged = true;
                        MenuCalc();
                    }
                }
            }
            else {
                tentativi = 0;
                Console.WriteLine("Login fallito. Riprova.");
                if (tentativi >= MaxTentativi)
                {
                    Console.WriteLine("Numero massimo di tentativi raggiunto. Accesso negato.");
                    isLoged = false;

                }
            }

        } while (!isLoged);
    }

    public static void MenuCalc() {

        Calcolatrice calcolatrice = new Calcolatrice();

        Console.WriteLine("Benvenuto nella calcolatrice!");
        Console.WriteLine("Scegli un'operazione: 1) Somma 2) Sottrazione 3) Moltiplicazione 4) Divisione");

        int scelta = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Inserisci il primo numero:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Inserisci il secondo numero:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        switch (scelta) {
            case 1:
                Console.WriteLine($"Risultato: {calcolatrice.somma(num1, num2)}");
                break;
            case 2:
                Console.WriteLine($"Risultato: {calcolatrice.sottrazione(num1, num2)}");
                break;
            case 3:
                Console.WriteLine($"Risultato: {calcolatrice.moltiplicazione(num1, num2)}");
                break;
            case 4:
                try
                {
                    Console.WriteLine($"Risultato: {calcolatrice.divisione(num1, num2)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;
            default:
                Console.WriteLine("Operazione non valida.");
                break;
        }
    }
}

public class Calcolatrice {
    
    public int somma(int a, int b)
    {
        return a + b;
    }

    public int sottrazione(int a, int b) {
        return a - b;
    }

    public int moltiplicazione(int a, int b) {
        return a * b;
    }

    public double divisione(int a, int b) {
        if (b == 0 || a == 0)
            throw new DivideByZeroException("Divisione per zero non e possibile.");
        else
            return (double)a / b;
    }
}

public class Utente {
        public string Password;
        public string Nickname;
        public int eta;
        public Utente(string password, string nickname, int eta) {
            this.Password = password;
            this.Nickname = nickname;
            this.eta = eta;
        }
    }