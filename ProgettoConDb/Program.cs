using System;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

/*
classe che gestisce la connessione al db
*/
public class Db
{
    private string connStr = "server=localhost;user=root;database=;port=3306;password=";
    public MySqlConnection conn;

    public Db()
    {
        conn = new MySqlConnection(connStr);
    }

    public void connectionDB()
    {
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    public void CloseConnection()
    {
        conn.Close();
        Console.WriteLine("Done.");
    }
}
/*
create table utenti 
(
	id int auto_increment primary key,
    nome varchar(50) not null unique,
    password varchar(100) not null,
    ruolo ENUM('admin', 'utente') NOT NULL DEFAULT 'utente'
); 
*/
public class Utente
{
    public string nome { get; set; }
    public string cognome { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public string Ruolo { get; set; }
    public void EffettuaRegistrazione(string nome, string cognome, string email, string password, string ruolo)
    {
        try
        {
            Db db = new Db();
            db.connectionDB();
            string sql = "INSERT INTO utente (Nome, cognome, email, password, ruolo) VALUES (@nome, @cognome, @email, @password, @ruolo)";
            using (MySqlCommand cmd = new MySqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@cognome", cognome);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@ruolo", ruolo);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} prodotto inserito correttamente.");
            }
            db.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'inserimento: " + ex.Message);
        }
    }
    public (bool successo, string ruolo) Login(string email, string password)
    {
        string connStr = "server=localhost;user=root;database=;port=3306;password=";
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string sql = "SELECT ruolo FROM utenti WHERE email = @email AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ruolo = reader.GetString("ruolo");
                            Console.WriteLine($"Login riuscito! Ruolo: {ruolo}");
                            return (true, ruolo);
                        }
                        else
                        {
                            Console.WriteLine("Email o password errati.");
                            return (false, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante il login: " + ex.Message);
                return (false, null);
            }
        }
    }
}

/*
CREATE TABLE prodotti (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descrizione TEXT,
    prezzo DECIMAL(10,2) NOT NULL
);
*/
public class Prodotto
{
    public string nome { get; set; }
    public string descrizione { get; set; }
    public string prezzo { get; set; }
    public void RimuoviProdotto(int id)
    {
        try
        {
            Db db = new Db();
            db.connectionDB();
            string sql = "DELETE FROM prodotti WHERE id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Prodotto rimosso correttamente.");
                else
                    Console.WriteLine("Nessun prodotto trovato con l'ID specificato.");
            }
            db.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'eliminazione: " + ex.Message);
        }
    }
    public void AggiungiProdotto(string nome, string descrizione, decimal prezzo)
    {
        try
        {
            Db db = new Db();
            db.connectionDB();
            string sql = "INSERT INTO prodotti (nome, descrizione, prezzo) VALUES (@nome, @descrizione, @prezzo)";
            using (MySqlCommand cmd = new MySqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.Parameters.AddWithValue("@descrizione", descrizione);
                cmd.Parameters.AddWithValue("@prezzo", prezzo);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} prodotto inserito correttamente.");
            }
            db.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'inserimento: " + ex.Message);
        }
    }
    public void TuttiProdottiDisponibili()
    {
        string connStr = "server=localhost;user=root;database=ristorante;port=3306;password=arcidemone92";
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string sql = "SELECT Id, Nome, Descrizione, Prezzo FROM prodotti";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("ID\tNome\t\tDescrizione\t\tPrezzo");
                    Console.WriteLine("------------------------------------------------------");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string nome = reader.GetString("Nome");
                        string descrizione = reader.GetString("Descrizione");
                        decimal prezzo = reader.GetDecimal("Prezzo");
                        Console.WriteLine($"{id}\t{nome}\t\t{descrizione}\t\t{prezzo} €");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la lettura dei prodotti: " + ex.Message);
            }
        }
    }
    
}
/*
CREATE TABLE carrelli (
    id INT AUTO_INCREMENT PRIMARY KEY,
    utente_id INT NOT NULL,
    prodotto_id INT NOT NULL,
    quantita INT NOT NULL DEFAULT 1,
    FOREIGN KEY (utente_id) REFERENCES utenti(id) ON DELETE CASCADE,
    FOREIGN KEY (prodotto_id) REFERENCES prodotti(id) ON DELETE CASCADE
); 
*/
public class Carrello
{
    public int Id { get; set; }
    public int UtenteId { get; set; }
    public int ProdottoId { get; set; }
    public int Quantita { get; set; }
    public void RimuoviProdottoDalCarrelo(int id)
    {
        try
        {
            Db db = new Db();
            db.connectionDB();
            string sql = "DELETE FROM carrelli WHERE prodotto_id = @id";
            using (MySqlCommand cmd = new MySqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Prodotto rimosso correttamente.");
                else
                    Console.WriteLine("Nessun prodotto trovato con l'ID specificato.");
            }
            db.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'eliminazione: " + ex.Message);
        }
    }

    public void AggiungiProdottoCarrello(int utenteId, int prodottoId, int quantita)
    {
        try
        {
            Db db = new Db();
            db.connectionDB();
            string sql = "INSERT INTO carrelli (utente_id, prodotto_id, quantita) VALUES (@utente_id, @prodotto_id, @quantita)";
            using (MySqlCommand cmd = new MySqlCommand(sql, db.conn))
            {
                cmd.Parameters.AddWithValue("@utente_id", utenteId);
                cmd.Parameters.AddWithValue("@prodotto_id", prodottoId);
                cmd.Parameters.AddWithValue("@quantita", quantita);
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsAffected} prodotto aggiunto al carrello.");
            }
            db.CloseConnection();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante l'inserimento nel carrello: " + ex.Message);
        }
    }
    
    public void VisualizzaCarrello(int utenteId)
    {
        string connStr = "server=localhost;user=root;database=;port=3306;password=";
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string sql = @"SELECT p.nome, p.descrizione, p.prezzo, c.quantita
                            FROM carrelli c
                            JOIN prodotti p ON c.prodotto_id = p.id
                            WHERE c.utente_id = @utente_id";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@utente_id", utenteId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine("Nome\tDescrizione\tPrezzo\tQuantità");
                        while (reader.Read())
                        {
                            string nome = reader.GetString("nome");
                            string descrizione = reader.GetString("descrizione");
                            decimal prezzo = reader.GetDecimal("prezzo");
                            int quantita = reader.GetInt32("quantita");
                            Console.WriteLine($"{nome}\t{descrizione}\t{prezzo}\t{quantita}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante la visualizzazione del carrello: " + ex.Message);
            }
        }
    }
}
/*
La classe che contiene il Main
*/

public class StoreDigitale
{
    public static void Main()
    {
        Menu();
    }

    public static void Menu()
    {
        Utente utente = new Utente();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("  Benvenuto nello Store Digitale!");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Visualizza prodotti");
            Console.WriteLine("2. Registrazione");
            Console.WriteLine("3. Login");
            Console.WriteLine("4. Esci");
            Console.Write("Seleziona un'opzione: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Ecco Tutti i prodotti disponibili");
                    Prodotto prodotto = new Prodotto();
                    prodotto.TuttiProdottiDisponibili();
                    break;
                case "2":
                    Console.WriteLine("Registrazione utente:");
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();
                    Console.Write("Cognome: ");
                    string cognome = Console.ReadLine();
                    Console.Write("Email: ");
                    string email = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Ruolo (admin/utente): ");
                    string ruolo = Console.ReadLine();
                    utente.EffettuaRegistrazione(nome, cognome, email, password, ruolo);
                    break;
                case "3":
                    Console.Write("Email: ");
                    string emailLogin = Console.ReadLine();
                    Console.Write("Password: ");
                    string passwordLogin = Console.ReadLine();

                    var risultato = utente.Login(emailLogin, passwordLogin);

                    if (risultato.successo)
                    {
                        Console.WriteLine($"Login riuscito! Ruolo: {risultato.ruolo}");
                        int utenteId = OttieniIdUtente(emailLogin); // Funzione helper per ottenere l'id utente
                        if (risultato.ruolo == "utente")
                            MenuUtente(utenteId);
                        else if (risultato.ruolo == "admin")
                            MenuAdmin();
                    }
                    else
                    {
                        Console.WriteLine("Email o password errati.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Grazie per averci scelto");
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Errore: scelta non valida");
                    break;
            }
        }
    }

    public static void MenuUtente(int utenteId)
    {
        Carrello carrello = new Carrello();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("  Benvenuto nel menu utente!");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Visualizza il carrello");
            Console.WriteLine("2. Aggiungi prodotto al carrello");
            Console.WriteLine("3. Rimuovi prodotto dal carrello");
            Console.WriteLine("4. Esci");
            Console.Write("Seleziona un'opzione: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Clear();
                    carrello.VisualizzaCarrello(utenteId);
                    break;
                case "2":
                    Console.Write("ID prodotto da aggiungere: ");
                    int prodottoId = int.Parse(Console.ReadLine());
                    Console.Write("Quantità: ");
                    int quantita = int.Parse(Console.ReadLine());
                    carrello.AggiungiProdottoCarrello(utenteId, prodottoId, quantita);
                    break;
                case "3":
                    Console.Write("ID prodotto da rimuovere: ");
                    int idRimuovi = int.Parse(Console.ReadLine());
                    carrello.RimuoviProdottoDalCarrelo(idRimuovi);
                    break;
                case "4":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Errore: scelta non valida");
                    break;
            }
        }
    }

    public static void MenuAdmin()
    {
        Prodotto prodotto = new Prodotto();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("  Benvenuto nel menu admin!");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Visualizza prodotti");
            Console.WriteLine("2. Aggiungi prodotto");
            Console.WriteLine("3. Rimuovi prodotto");
            Console.WriteLine("4. Esci");
            Console.Write("Seleziona un'opzione: ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Clear();
                    prodotto.TuttiProdottiDisponibili();
                    break;
                case "2":
                    Console.Write("Nome prodotto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Descrizione: ");
                    string descrizione = Console.ReadLine();
                    Console.Write("Prezzo: ");
                    decimal prezzo = decimal.Parse(Console.ReadLine());
                    prodotto.AggiungiProdotto(nome, descrizione, prezzo);
                    break;
                case "3":
                    Console.Write("ID prodotto da rimuovere: ");
                    int id = int.Parse(Console.ReadLine());
                    prodotto.RimuoviProdotto(id);
                    break;
                case "4":
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Errore: scelta non valida");
                    break;
            }
        }
    }

    // Funzione helper per ottenere l'id utente tramite email
    public static int OttieniIdUtente(string email)
    {
        int id = -1;
        string connStr = "server=localhost;user=root;database=ristorante;port=3306;password=arcidemone92";
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string sql = "SELECT id FROM utenti WHERE email = @email";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = reader.GetInt32("id");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore durante il recupero dell'id utente: " + ex.Message);
            }
        }
        return id;
    }
}
