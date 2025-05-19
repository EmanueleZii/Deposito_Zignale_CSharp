/*
Sono  raggruppati in un'unica classe i metodi che sono stati creati per gli esercizi di programmazione.
*/
class Programs
{


    static void Main(string[] args)
    {

    }
    static void chiedinumeri(int num1 = 0, int num2 = 0)
    {
        try
        {
            Console.WriteLine("Inserisci il primo numero:");
            num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            num2 = int.Parse(Console.ReadLine());
        }
        catch (Exception e)
        {
            Console.WriteLine($"Errore: inserire un numero valido {e}");
        }
        finally
        {
            Console.WriteLine($"I numeri inseriti sono: {num1} e {num2}");
        }
    }
    static void Dividi()
    {
        int a, b;
        try
        {
            Console.WriteLine("Inserisci il primo numero:");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine($"La divisione di {a} e {b} è: {a / b}");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Errore: divisione per zero");
        }
    }
    static void Somma()
    {
        int somma = 0;
        bool inputValido = false;
        while (inputValido == false)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    Console.WriteLine("Inserisci il numero da sommare:");
                    int num = int.Parse(Console.ReadLine());
                    somma += num;
                    inputValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Errore: inserire un numero valido");
                }
            }
            Console.WriteLine($"La somma è: {somma}");
        }
    }
    static int Somma(int a, int b)
    {
        Console.WriteLine($"La somma di {a} e {b} è: {a + b}");
        return a + b;
    }
    static double Somma(double a, double b)
    {
        Console.WriteLine($"La somma di {a} e {b} è: {a + b}");
        return a + b;
    }
    static int Somma(int a, int b, int c)
    {
        Console.WriteLine($"La somma di {a} e {b} e {c} è: {a + b + c}");
        return a + b + c;
    }
    static void Analizza(string messaggio)
    {
        Console.WriteLine("Analizza");
        int lunghezza = 0;
        Console.WriteLine($"Il messaggio è: {messaggio}");
        if (messaggio != null)
        {
            foreach (char lettera in messaggio)
            {
                if (!char.IsWhiteSpace(lettera))
                    lunghezza++;
            }
        }
        Console.WriteLine($"La lunghezza del messaggio è: {lunghezza}");
    }
    static void Analizza(string messaggio, bool contaVocali)
    {
        int contatoreV = 0;
        int contatoreC = 0;
        string vocali = "aeiou";
        string consonanti = "bcdfghjklmnpqrstvwxyz";
        if (messaggio != null)
        {
            foreach (char lettera in messaggio)
            {
                if (!char.IsWhiteSpace(lettera))
                {
                    if (contaVocali)
                    {
                        if (vocali.Contains(char.ToLower(lettera)))
                            contatoreV++;
                    }
                    else
                    {
                        if (consonanti.Contains(char.ToLower(lettera)))
                            contatoreC++;
                    }
                }
            }
        }
        Console.WriteLine($"La frase contiene {contatoreV} vocali {contatoreC}consonanti contavocali:  {contaVocali}");
    }
    static void Analizza(string messaggio, char carattere)
    {
        Console.WriteLine("Inserisci una frase:");
        messaggio = Console.ReadLine();
        int contatore = 0;
        foreach (char lettera in messaggio)
        {
            if (char.ToLower(lettera) == carattere)
                contatore++;
        }
        Console.WriteLine($"Il carattere {carattere} è presente nella frase {contatore} volte");
    }

    static void ElaboraStudente(ref int voto1, ref int voto2, ref string nome, out int media)
    {
        Console.WriteLine("Elabora studente");
        Console.WriteLine("Inserisci il nome dello studente:");
        nome = Console.ReadLine();
        Console.WriteLine($"Voto 1: {voto1}");
        Console.WriteLine($"Voto 2: {voto2}");

        //la media
        media = (voto1 + voto2) / 2;
        Console.WriteLine($"La media dei voti è: {media}");
        if (media > 6)
            Console.WriteLine("Hai superato la prova");
        else
            Console.WriteLine("Prova fallita");
    }
    static void AggiornaPunteggio(ref int punteggio1, ref int punteggio2, ref int punteggio3, out int totale, out int media, int bonus1, int bonus2, int bonus3)
    {
        Console.WriteLine("Aggiorna il punteggio");
        punteggio1 = 10;
        punteggio2 = 10;
        punteggio3 = 10;
        punteggio1 += bonus1;
        punteggio2 += bonus2;
        punteggio3 += bonus3;
        Console.WriteLine($"Punteggio 1: {punteggio1}");
        Console.WriteLine($"Punteggio 2: {punteggio2}");
        Console.WriteLine($"Punteggio 3: {punteggio3}");
        totale = punteggio1 + punteggio2 + punteggio3;
        Console.WriteLine($"Il totale dei punteggi è: {totale}");
        //la media
        media = (punteggio1 + punteggio2 + punteggio3) / 2;
        Console.WriteLine($"La media dei punteggi è: {media}");
    }
    static void StampaMessaggio(out int quoziente, out int resto)
    {
        Console.WriteLine("Inserisci un numero:");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci un altro numero:");
        int numero2 = int.Parse(Console.ReadLine());
        quoziente = numero / numero2;
        resto = numero % numero2;
        Console.WriteLine($"Il quoziente è: {quoziente}");
        Console.WriteLine($"Il resto è: {resto}");
    }
    // static void AggiornaPunteggio(ref int punteggio1, ref int punteggio2, ref int punteggio3, int bonus, out int totale, out int media)
    // {
    //     //aggiunge punti bonus al punteggio 
    //     punteggio1 += bonus;
    //     punteggio2 += bonus;
    //     punteggio3 += bonus;

    //     //calcola totale e media
    //     totale = punteggio1 + punteggio2 + punteggio3;
    //     media = totale / 3;
    // }
    static void contaVocaliConsonanti(out int contatorevocali, out int contatoreConsonanti, out int contatorespazi)
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci una frase:");
        string frase = Console.ReadLine();
        contatorevocali = 0;
        contatoreConsonanti = 0;
        string vocali = "aeiouAEIOU";
        string consonanti = "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ";
        contatorespazi = 0;
        if (frase != null)
        {
            foreach (char lettera in frase)
            {
                if (vocali.Contains(lettera))
                    contatorevocali++;
                if (consonanti.Contains(lettera))
                    contatoreConsonanti++;
                if (char.IsWhiteSpace(lettera))
                    contatorespazi++;
            }
        }
        Console.WriteLine($"La frase contiene {contatorevocali} vocali e {contatoreConsonanti} consonanti");
    }
    static void AggiustaData(ref int giorno, ref int mese, ref int anno)
    {
        Console.WriteLine($"Data: {giorno}/{mese}/{anno}");
        // Aggiusta la data
        giorno = 1;
        mese = 1;
        anno = 2023;
        Console.WriteLine($"Data corretta: {giorno}/{mese}/{anno}");
        // Verifica se la data è valida
        if (giorno > 31 || mese > 12 || anno < 0)
        {
            Console.WriteLine("Data non valida");
            return;
        }
        if (giorno > 31)
        {
            giorno = 1;
            mese++;
        }
        else if (mese > 12)
        {
            mese = 1;
            anno++;
        }
        Console.WriteLine($"Data corretta: {giorno}/{mese}/{anno}");

    }
    static void Aumenta(ref int numero)
    {
        Console.WriteLine($"Il numero è: {numero}");
        Console.WriteLine("Aumento di 10");
        numero += 10;
        Console.WriteLine($"Il numero è: {numero}");
    }
    static double CalcolaPotenza(double baseNumero, double esponente)
    {
        double risultato = Math.Pow(baseNumero, esponente);

        Console.WriteLine($"{baseNumero}^{esponente} = {risultato}");
        return risultato;
    }
    static bool VerificaPari(int numero)
    {
        bool risultato = false;
        if (numero % 2 == 0)
        {
            Console.WriteLine("Il numero è pari");
            risultato = true;
        }
        else
        {
            Console.WriteLine("Il numero è dispari");
            risultato = false;
        }
        return risultato;
    }
    static string StampaSaluto(string nome)
    {
        return $"Ciao {nome}, benvenuto!";
    }
    static void Password2()
    {

        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci una password:");

        string password = Console.ReadLine();

        if (string.IsNullOrEmpty(password))
        {
            Console.WriteLine("La stringa è vuota");
            return;
        }

        if (password.StartsWith(" ") || password.EndsWith(" "))
        {
            Console.WriteLine("La password non può iniziare o finire con uno spazio.");
            return;
        }

        if (password.Length < 8)
        {
            Console.WriteLine("La password deve contenere almeno 8 caratteri.");
            return;
        }

        bool contieneNumero = false;
        bool contieneSpazioInterno = false;
        bool contieneMaiuscola = false;

        foreach (char c in password)
        {
            if (char.IsDigit(c))
                contieneNumero = true;
            if (char.IsWhiteSpace(c))
                contieneSpazioInterno = true;
            if (char.IsUpper(c))
                contieneMaiuscola = true;
        }

        if (!contieneNumero)
        {
            Console.WriteLine("La password deve contenere almeno un numero.");
            return;
        }

        if (!contieneMaiuscola)
        {
            Console.WriteLine("La password deve contenere almeno una lettera maiuscola.");
            return;
        }

        if (contieneSpazioInterno)
        {
            Console.WriteLine("La password non può contenere spazi.");
            return;
        }

        Console.WriteLine("Password valida!");
    }
    /* esercizi fatti */
    static void senzaSpazi()
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci una frase: ");
        string frase = Console.ReadLine();
        string fraseSenzaSpazi = "";
        foreach (char lettera in frase)
        {
            if (char.IsWhiteSpace(lettera))
                continue;
            else
                fraseSenzaSpazi += lettera;
        }
        Console.WriteLine($"La frase senza spazi è: {fraseSenzaSpazi}");
    }
    static void frase()
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Scrivi una frase:");
        string frase = Console.ReadLine();
        int contatore = 0;
        foreach (char lettera in frase)
        {
            if (char.IsDigit(lettera))
                contatore++;
        }
        Console.WriteLine($"la frase contiene {contatore} numeri");
    }
    static void numeroVocali()
    {

        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci una frase:");
        string frase = Console.ReadLine();
        int contatore = 0;
        string vocali = "aeiouAEIOU";
        if (frase != null)
        {
            foreach (char lettera in frase)
            {
                if (vocali.Contains(lettera))
                    contatore++;
            }
        }
        Console.WriteLine($"La frase contiene {contatore} vocali");
    }
    static void stringa()
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci una stringa:");

        string frase = Console.ReadLine();

        int parole = 0;
        int contatorenum = 0;
        int contatorelettere = 0;
        int contatorespazi = 0;
        int contatorepunteggiatura = 0;
        if (frase == null)
        {
            Console.WriteLine("La stringa è vuota");
            return;
        }

        foreach (char lettera in frase)
        {
            // Conteggio parole
            parole = frase.Split(' ').Length;

            if (char.IsDigit(lettera))
                contatorenum++;
            else if (char.IsLetter(lettera))
                contatorelettere++;
            else if (char.IsWhiteSpace(lettera))
                contatorespazi++;
            else if (char.IsPunctuation(lettera))
                contatorepunteggiatura++;
        }
        Console.WriteLine($"La stringa contiene : ");
        Console.WriteLine($"Numeri: {contatorenum}");
        Console.WriteLine($"Lettere: {contatorelettere}");
        Console.WriteLine($"Spazi: {contatorespazi}");
        Console.WriteLine($"Punteggiatura: {contatorepunteggiatura}");
        Console.WriteLine($"Parole: {parole}");
    }
    static void calcolomedia()
    {
        double media = 0;
        double somma = 0;
        double contatore = 0;
        double quantinumeri = 0;
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci quanti numeri vuoi sommare:");
        quantinumeri = int.Parse(Console.ReadLine());
        for (int i = 0; i < quantinumeri; i++)
        {
            Console.WriteLine("Inserisci un numero:");
            double numero = int.Parse(Console.ReadLine());
            somma += numero;
            media = somma / quantinumeri;
        }
        Console.WriteLine($"La media è: {media}");
    }
    static void Fattoriale()
    {
        int fattoriale = 1;

        Console.WriteLine("Esercizio:");
        Console.WriteLine("Inserisci un numero:");

        int numero = int.Parse(Console.ReadLine());

        if (numero < 0)
        {
            Console.WriteLine("Il fattoriale non è definito per i numeri negativi.");
            return;
        }

        for (int i = 1; i <= numero; i++)
        {
            fattoriale *= i;
        }

        Console.WriteLine($"Il fattoriale di {numero} è {fattoriale}");
    }
    static void StampaTabellina()
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Stampa la moltiplicazione di un numero a tua scelta");
        Console.WriteLine("Inserisci un numero:");
        int numero = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tabellina del {numero}:");

        for (int i = 1; i <= 10; i++)
        {
            int risultato = numero * i;
            Console.WriteLine($"{numero} x {i} = {risultato}");
        }
    }
    static void Calc()
    {
        Console.WriteLine("Esercizio:");
        Console.WriteLine("Benvenuto nel programma calcolatore");
        bool continua = true;
        do
        {
            Console.WriteLine("Scegli un operazione:");
            Console.WriteLine("1. Somma");
            Console.WriteLine("2. Sottrazione");
            Console.WriteLine("3. Moltiplicazione");
            Console.WriteLine("4. Divisione");
            Console.WriteLine("5. Modulo");
            Console.WriteLine("6. Uscita");

            int scelta = int.Parse(Console.ReadLine());
            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Inserisci il primo numero:");
                    double numero1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero:");
                    double numero2 = double.Parse(Console.ReadLine());
                    double risultato = numero1 + numero2;
                    Console.WriteLine($"Il risultato della somma è: {risultato}");
                    break;
                case 2:
                    Console.WriteLine("Inserisci il primo numero:");
                    double numero3 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero:");
                    double numero4 = double.Parse(Console.ReadLine());
                    double risultato2 = numero3 - numero4;
                    Console.WriteLine($"Il risultato della sottrazione è: {risultato2}");
                    break;
                case 3:
                    Console.WriteLine("Inserisci il primo numero:");
                    double numero5 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero:");
                    double numero6 = double.Parse(Console.ReadLine());
                    double risultato3 = numero5 * numero6;
                    Console.WriteLine($"Il risultato della moltiplicazione è: {risultato3}");
                    break;
                case 4:
                    Console.WriteLine("Inserisci il primo numero:");
                    double num5 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero:");
                    double num6 = double.Parse(Console.ReadLine());
                    double ris4 = num5 / num6;
                    Console.WriteLine($"Il risultato della moltiplicazione è: {ris4}");
                    break;
                case 5:
                    Console.WriteLine("Inserisci il primo numero:");
                    double num7 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Inserisci il secondo numero:");
                    double num8 = double.Parse(Console.ReadLine());
                    double ris5 = num7 % num8;
                    Console.WriteLine($"Il risultato della moltiplicazione è: {ris5}");
                    break;
                default:
                    Console.WriteLine("Sei Sicuro di voler uscire? (si/no)");
                    string risposta = Console.ReadLine().ToLower();
                    if (risposta == "si")
                        continua = false;
                    else if (risposta == "no")
                        continua = true;
                    else
                        Console.WriteLine("Risposta non valida. Riprova.");
                    break;

            }

        } while (continua);
    }
    static void zero()
    {
        int numero = 0;
        int sommaTutto = 0;
        bool continua = true;

        Console.WriteLine("Esercizio:");

        do
        {
            Console.WriteLine("Inserisci un numero:");
            numero = int.Parse(Console.ReadLine());
            if (numero >= 1)
            {
                sommaTutto += numero;
            }
            else if (numero == 0)
            {
                Console.WriteLine($"La somma è: {sommaTutto}");
                break;
                continua = false;
            }

        } while (continua);
    }
    static void Password()
    {
        const string password = "1234";
        string passwordInseriti = "";
        int tentativi = 0;
        Console.WriteLine("Benvenuto nel programma di accesso");
        do
        {
            Console.WriteLine("Enter your password: ");
            passwordInseriti = Console.ReadLine();
            tentativi++;
            if (tentativi == 3)
            {
                Console.WriteLine("Troppi tentativi. Accesso negato.");
                break;
            }
        } while (passwordInseriti != "1234");

    }
    static void indovinaIlNumero()
    {
        const int numeroDaIndovinare = 69;
        int tentativi = 0;
        bool indovinato = false;
        Console.WriteLine("Benvenuto nel gioco 'Indovina il numero'!");
        Console.WriteLine("Ho scelto un numero tra 1 e 100. Prova a indovinarlo!");
        while (!indovinato)
        {
            Console.WriteLine("Inserisci un numero:");
            int numeroInserito = int.Parse(Console.ReadLine());
            tentativi++;

            if (numeroInserito < numeroDaIndovinare)
                Console.WriteLine("Il numero è più alto.");

            else if (numeroInserito > numeroDaIndovinare)
                Console.WriteLine("Il numero è più basso.");

            else
            {
                indovinato = true;
                Console.WriteLine($"Congratulazioni! Hai indovinato il numero {numeroDaIndovinare} in {tentativi} tentativi.");
            }
        }
    }
    static void Conteggio()
    {
        int contatore = 0;
        bool continua = true;
        int risultato = 0;
        Console.WriteLine("Esercizio:");
        while (continua)
        {
            Console.WriteLine("Inserisci un numero positivo da conteggiare poi alla fine un numero negativo per finire:");
            int numero = int.Parse(Console.ReadLine());
            if (numero > 0)
            {
                int somma = 0;
                risultato = somma + numero;
            }
            else if (numero < 0)
            {
                continua = false;
                Console.WriteLine($"Hai inserito {risultato} numeri positivi");
            }
            contatore++;
        }
    }
    static void GiornoDellaSettimana()
    {
        Console.WriteLine("Esercizio:");

        Console.WriteLine("Scegli un giorno della settimana:");
        Console.WriteLine("1. Lunedì");
        Console.WriteLine("2. Martedì");
        Console.WriteLine("3. Mercoledì");
        Console.WriteLine("4. Giovedì");
        Console.WriteLine("5. Venerdì");
        Console.WriteLine("6. Sabato");
        Console.WriteLine("7. Domenica");
        // Chiedi all'utente di inserire un numero da 1 a 7
        Console.WriteLine("Inserisci un numero da 1 a 7:");
        int giorno = int.Parse(Console.ReadLine());
        // Verifica se il numero è compreso tra 1 e 7
        switch (giorno)
        {
            case 1:
                Console.WriteLine("Lunedì");
                break;
            case 2:
                Console.WriteLine("Martedì");
                break;
            case 3:
                Console.WriteLine("Mercoledì");
                break;
            case 4:
                Console.WriteLine("Giovedì");
                break;
            case 5:
                Console.WriteLine("Venerdì");
                break;
            case 6:
                Console.WriteLine("Sabato");
                break;
            case 7:
                Console.WriteLine("Domenica");
                break;
            default:
                Console.WriteLine("Numero non valido. Inserisci un numero da 1 a 7.");
                break;
        }
    }
    static void FiguraGeometrica()
    {
        Console.WriteLine("Esercizio:");

        Console.WriteLine("Scegli una figura geometrica:");
        Console.WriteLine("1. Cerchio");
        Console.WriteLine("2. Quadrato");
        Console.WriteLine("3. Rettangolo");
        // Chiedi all'utente di inserire un numero da 1 a 3
        Console.WriteLine("Inserisci un numero da 1 a 3:");
        int figura = int.Parse(Console.ReadLine());
        // Verifica se il numero è compreso tra 1 e 3
        switch (figura)
        {

            case 1:
                Console.WriteLine("Hai scelto il cerchio");
                Console.WriteLine("Inserisci il raggio del cerchio:");
                double raggio = double.Parse(Console.ReadLine());
                // Calcolo dell'area del cerchio
                double areaCerchio = Math.PI * raggio * raggio;
                Console.WriteLine($"Area del cerchio: {areaCerchio}");
                break;

            case 2:
                Console.WriteLine("Hai scelto il quadrato");
                Console.WriteLine("Inserisci il lato del quadrato:");
                double lato = double.Parse(Console.ReadLine());
                // Calcolo dell'area del quadrato
                double areaQuadrato = lato * lato;
                Console.WriteLine($"Area del quadrato: {areaQuadrato}");
                break;

            case 3:
                Console.WriteLine("Hai scelto il triangolo");
                Console.WriteLine("Inserisci la base del triangolo:");
                double baseTriangolo = double.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci l'altezza del triangolo:");
                double altezzaTriangolo = double.Parse(Console.ReadLine());
                // Calcolo dell'area del triangolo
                double areaTriangolo = (baseTriangolo * altezzaTriangolo) / 2;
                // Stampa dell'area del triangolo 
                Console.WriteLine($"Area del triangolo: {areaTriangolo}");
                break;

            default:
                Console.WriteLine("Numero non valido. Inserisci un numero da 1 a 3.");
                break;
        }
    }
    static void SommaDueNumeri()
    {
        int num1 = 10;
        int num2 = 20;
        int somma = num1 + num2;

        Console.WriteLine("Esercizio 1:");
        Console.WriteLine($"La somma di {num1} e {num2} è {somma}");
    }
    static void Sconto()
    {
        double prezzoOriginale = 100.0;
        double prezzoScontato = prezzoOriginale * 20 / 100;
        double prezzoFinale = prezzoOriginale - prezzoScontato;

        Console.WriteLine("Esercizio 2:");
        Console.WriteLine("Prezzo scontato: " + prezzoFinale.ToString());
    }
    static void sconto2()
    {
        double prezzoOriginale = 100.0;
        //espressione booleana
        bool scontoApplicato = prezzoOriginale > 50.0;
        Console.WriteLine("Esercizio 3:");
        Console.WriteLine("superiore a 50: " + prezzoOriginale);
    }
    static void QuartoEsercizio()
    {
        Console.WriteLine("Esercizio 4:");

        Console.WriteLine("Inserisci un numero intero:");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci un numero decimale:");
        float numerovirgola = float.Parse(Console.ReadLine());

        Console.WriteLine($"la somma {numero} {numerovirgola}: {numero + numerovirgola}");
    }
    static void SommaAltezzaPeso()
    {
        Console.WriteLine("Esercizio 5:");

        Console.WriteLine("Inserisci un eta:");
        int eta = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci l'altezza:");

        float altezza = float.Parse(Console.ReadLine());
        Console.WriteLine($"la somma {eta} {altezza}: {eta + altezza}");
    }
    static void MaggiorenneOMinorenne()
    {
        Console.WriteLine("Esercizio 6:");

        int voto = 18;
        const int soglia = 18;

        Console.WriteLine("Inserisci il tua eta:");
        int eta = int.Parse(Console.ReadLine());

        if (voto >= soglia)
            Console.WriteLine("Sei maggiorenne");
        else
            Console.WriteLine("Sei minorenne");
    }
    static void PrezzoProdotto()
    {
        Console.WriteLine("Esercizio 7:");
        Console.WriteLine($"Inserisci il prezzo del prodotto:");

        double prezzoOriginale = double.Parse(Console.ReadLine());
        const int prezzomassimo = 100;

        if (prezzoOriginale >= prezzomassimo)
        {
            Console.WriteLine("Il prezzo è superiore a 100");
            Console.WriteLine("Hai diritto a uno sconto del 10%");
            // Calcolo dello sconto
            double prezzoScontato = prezzoOriginale * 10 / 100;
            double prezzoFinale = prezzoOriginale - prezzoScontato;
            Console.WriteLine("Prezzo scontato:" + prezzoFinale.ToString());
        }
        else Console.WriteLine("Il prezzo è inferiore a 100");
    }
    static void LaMedia()
    {
        Console.WriteLine("Esercizio 8:");

        Console.WriteLine("Inserisci il primo numero:");
        int numero = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il secondo numero:");
        int numero2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Inserisci il terzo numero:");
        int numero3 = int.Parse(Console.ReadLine());

        int media = (numero + numero2 + numero3) / 3;
        double media2 = double.Parse(media.ToString());

        // Calcolo della media
        Console.WriteLine($"La media dei tre numeri è: {media2}");
        // Verifica se la media è maggiore o uguale a 60
        // e stampa il risultato
        if (media2 >= 60)
            Console.WriteLine("hai superato la prova");
        else
            Console.WriteLine("Prova fallita");
    }
    static void PariODispari()
    {
        Console.WriteLine("Esercizio 11:");
        Console.WriteLine("Inserisci un numero:");
        int numero = int.Parse(Console.ReadLine());
        // Verifica se il numero è pari o dispari
        if (numero % 2 == 0)
            Console.WriteLine("Il numero è pari");
        else
            Console.WriteLine("Il numero è dispari");
    }
    static void password()
    {
        Console.WriteLine("Esercizio 12:");
        Console.WriteLine("Inserisci un password:");
        const int password = 1234;
        int passwordinserita = int.Parse(Console.ReadLine());
        // Verifica se la password è corretta
        if (passwordinserita == password)
            Console.WriteLine("Accesso consentito");
        else
            Console.WriteLine("Accesso negato");
    }
    static void calcolatore()
    {
        Console.WriteLine("Esercizio 13:");

        Console.WriteLine("Bennuto nel programma calcolatore");
        Console.WriteLine("Scegli un operazione:");
        Console.WriteLine("1. Somma");
        Console.WriteLine("2. Sottrazione");
        Console.WriteLine("3. Moltiplicazione");
        Console.WriteLine("4. Divisione");
        Console.WriteLine("5. Modulo");

        int scelta = int.Parse(Console.ReadLine());
        // Verifica se la scelta è valida
        if (scelta < 1 || scelta > 5)
        {
            Console.WriteLine("Scelta non valida");
            return;
        }
        if (scelta == 1)
        {
            Console.WriteLine("Inserisci il primo numero:");
            double numero1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            double numero2 = double.Parse(Console.ReadLine());
            double risultato = numero1 + numero2;
            Console.WriteLine($"Il risultato della somma è: {risultato}");
        }
        if (scelta == 2)
        {
            Console.WriteLine("Inserisci il primo numero:");
            double numero1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            double numero2 = double.Parse(Console.ReadLine());
            double risultato = numero1 - numero2;
            Console.WriteLine($"Il risultato della somma è: {risultato}");
        }
        if (scelta == 3)
        {
            Console.WriteLine("Inserisci il primo numero:");
            double numero1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            double numero2 = double.Parse(Console.ReadLine());
            double risultato = numero1 * numero2;
            Console.WriteLine($"Il risultato della somma è: {risultato}");
        }
        if (scelta == 4)
        {
            Console.WriteLine("Inserisci il primo numero:");
            double numero1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            double numero2 = double.Parse(Console.ReadLine());
            double risultato = numero1 / numero2;
            Console.WriteLine($"Il risultato della somma è: {risultato}");
        }
        if (scelta == 5)
        {
            Console.WriteLine("Inserisci il primo numero:");
            double numero1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci il secondo numero:");
            double numero2 = double.Parse(Console.ReadLine());
            double risultato = numero1 % numero2;
            Console.WriteLine($"Il risultato della somma è: {risultato}");
        }
    }
    static void Voto()
    {
        Console.WriteLine("Esercizio 9:");
        Console.WriteLine("Un Voto a 1 a 10 :");
        int voto = int.Parse(Console.ReadLine());

        // Verifica se il voto è compreso tra 1 e 10
        if (voto < 1 || voto > 10)
            Console.WriteLine("Voto non valido. Inserisci un numero tra 1 e 10.");
        if (voto >= 1 && voto <= 4)
            Console.WriteLine("Insufficiente");
        else if (voto >= 5 && voto <= 6)
            Console.WriteLine("Sufficiente");
        else if (voto >= 7 && voto <= 8)
            Console.WriteLine("Buono");
        else if (voto >= 9 && voto <= 10)
            Console.WriteLine("Ottimo");
        else
            Console.WriteLine("Voto non valido. Inserisci un numero tra 1 e 10.");
    }
    static void Bmi()
    {
        Console.WriteLine("Esercizio 10:");
        Console.WriteLine("Inserisci il tuo peso:");
        double peso = double.Parse(Console.ReadLine());
        Console.WriteLine("Inserisci la tua altezza:");
        double altezza = double.Parse(Console.ReadLine());
        // Calcolo del BMI
        double bmi = peso / (altezza * altezza);
        // Verifica se il BMI è inferiore a 18.5    
        if (bmi < 18.5)
            Console.WriteLine("Sei sottopeso");
        else if (bmi >= 18.5 && bmi <= 24.9)
            Console.WriteLine("Hai un peso normale");
        else if (bmi >= 25 && bmi <= 29.9)
            Console.WriteLine("Sei in sovrappeso");
        else
            Console.WriteLine("Sei obeso");
        Console.WriteLine($"Il tuo BMI è: {bmi}");
    }
    static void Temperatura()
    {
        Console.WriteLine("Esercizio 14:");
        Console.WriteLine("Scegli la Temperatura da inserire:");
        Console.WriteLine("1. Celsius");
        Console.WriteLine("2. Fahrenheit");
        Console.WriteLine("3. Kelvin");

        int sceltatempinserita = int.Parse(Console.ReadLine());
        double temperatura = 0;

        if (sceltatempinserita == 1)
        {
            Console.WriteLine("Inserisci la Temperatura in Celsius:");
            temperatura = double.Parse(Console.ReadLine());
            // Converti Fahrenheit in Celsius
            double celsius = (temperatura - 32) * 5 / 9;
            Console.WriteLine($"La temperatura in Celsius è: {celsius}");
        }
        else if (sceltatempinserita == 2)
        {
            Console.WriteLine("Inserisci la Temperatura in Fahrenheit:");
            temperatura = double.Parse(Console.ReadLine());
            // Converti Celsius in Fahrenheit
            double fahrenheit = (temperatura * 9 / 5) + 32;
            Console.WriteLine($"La temperatura in Fahrenheit è: {fahrenheit}");

        }
        else if (sceltatempinserita == 3)
        {
            Console.WriteLine("Inserisci la Temperatura in Kelvin:");
            temperatura = double.Parse(Console.ReadLine());
            // Converti Kelvin in Celsius
            double celsius = temperatura - 273.15;
            Console.WriteLine($"La temperatura in Celsius è: {celsius}");
        }
        else
            Console.WriteLine("Scelta non valida");

        Console.WriteLine("Scegli la Temperatura da Convertire:");
        Console.WriteLine("1. Celsius");
        Console.WriteLine("2. Fahrenheit");
        Console.WriteLine("3. Kelvin");

        int scelta = int.Parse(Console.ReadLine());

        if (scelta == 1)
        {
            // Converti Celsius in Fahrenheit
            double fahrenheit = (temperatura * 9 / 5) + 32;
            Console.WriteLine($"La temperatura in Fahrenheit è: {fahrenheit}");
        }
        else if (scelta == 2)
        {
            // Converti Fahrenheit in Celsius
            double celsius = (temperatura - 32) * 5 / 9;
            Console.WriteLine($"La temperatura in Celsius è: {celsius}");
        }
        else if (scelta == 3)
        {
            // Converti Celsius in Kelvin
            double kelvin = temperatura + 273.15;
            Console.WriteLine($"La temperatura in Kelvin è: {kelvin}");
        }
        else
            Console.WriteLine("Scelta non valida");
    }



}