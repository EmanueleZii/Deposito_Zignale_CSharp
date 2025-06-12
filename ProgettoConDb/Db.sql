using StoreDigitale;

create database StoreDigitale

-- tabella utenti
create table utenti 
(
	id int auto_increment primary key,
    nome varchar(50) not null unique,
    password varchar(100) not null,
    ruolo ENUM('admin', 'utente') NOT NULL DEFAULT 'utente'
); 

-- Tabella prodotti
CREATE TABLE prodotti (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descrizione TEXT,
    prezzo DECIMAL(10,2) NOT NULL
);

-- Tabella carrelli
CREATE TABLE carrelli (
    id INT AUTO_INCREMENT PRIMARY KEY,
    utente_id INT NOT NULL,
    prodotto_id INT NOT NULL,
    quantita INT NOT NULL DEFAULT 1,
    FOREIGN KEY (utente_id) REFERENCES utenti(id) ON DELETE CASCADE,
    FOREIGN KEY (prodotto_id) REFERENCES prodotti(id) ON DELETE CASCADE
); 