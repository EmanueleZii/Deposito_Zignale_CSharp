using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

/*
classe che gestisce la connessione al db
*/
public class Db
{
    private string connStr = "server=localhost;user=root;database=ristorante;port=3306;password=arcidemone92";
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

    public void Effettualogin(string nome, string cognome, string email, string password, string ruolo)
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
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descrizione { get; set; }
    public decimal Prezzo { get; set; }

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

    public void VisualizzaProdotti()
    {
        string connStr = "server=localhost;user=root;database=ristorante;port=3306;password=arcidemone92";
        using (MySqlConnection conn = new MySqlConnection(connStr))
        {
            try
            {
                conn.Open();
                string sql = "SELECT Id, utente_id, prodotto_id, quantita FROM carrelli";
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("ID\tUtenteID\tProdottoID\tQuantità");
                    Console.WriteLine("------------------------------------------------------");
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        int utenteid = reader.GetInt32("utente_id");
                        int prodottoid = reader.GetInt32("prodotto_id");
                        int quantita = reader.GetInt32("quantita");
                        Console.WriteLine($"{id}\t{utenteid}\t\t{prodottoid}\t\t{quantita}");
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
La classe che contiene il Main
*/
public class StoreDigitale
{

    public static void Main()
    {
        Login();
    }
    public static void Login()
    {
        Db connect = new Db();
        connect.connectionDB();
        Utente utente = null;
        bool continua = true;
        while (continua)
        {
            Console.WriteLine("===================================");
            Console.WriteLine("  Benvenuto nello Store Digitale!");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Visualizza prodotti");
            Console.WriteLine("2. Effettua login");
            Console.WriteLine("3. Visualizza carrello");
            Console.WriteLine("4. Esci");
            Console.Write("Seleziona un'opzione: ");
            string scelta = Console.ReadLine();
            switch (scelta)
            {
                case "1":
                    Console.WriteLine("Ecco Tutti i prodotti disponibili");
                    break;
                case "2":
                    Console.WriteLine("Effettua il login:");
                    utente = new Utente();
                    Console.WriteLine("Inserisci il tuo nome");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Inserisci il tuo Cognome");
                    string cognome = Console.ReadLine();
                    Console.WriteLine("Inserisci il tuo email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Inserisci il tuo password");
                    string password = Console.ReadLine();
                    Console.WriteLine("Ruolo");
                    string ruolo = Console.ReadLine();
                    
                    utente.Effettualogin(nome, cognome, email, password, ruolo);
                    break;
                case "3":
                    Console.WriteLine("Ecco il Carrello:");
                    break;
                case "4":
                    Console.WriteLine("Grazie per  averci scelto");
                    Console.Clear();
                    continua = false;
                    break;
                default:
                    Console.Write("Errore scelta non valida");
                    break;
            }
        }

    }

}