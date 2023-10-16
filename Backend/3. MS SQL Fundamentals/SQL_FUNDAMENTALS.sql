CREATE DATABASE SQL_FUNDAMENTALS
USE SQL_FUNDAMENTALS;

CREATE TABLE Persoane (
    PersoanaID INT PRIMARY KEY,
    Nume VARCHAR(100),
    Adresa VARCHAR(100)
)

CREATE TABLE Comenzi (
    ComandaID INT PRIMARY KEY,
    Descriere TEXT,
    PersoanaID INT,
    FOREIGN KEY (PersoanaID) REFERENCES Persoane(PersoanaID)
)

CREATE TABLE Produse (
    ProdusID INT PRIMARY KEY,
    NumeProdus VARCHAR(100),
    Pret DECIMAL(10, 2)
);

CREATE TABLE ComenziProduse (
    ComandaID INT,
    ProdusID INT,
    Cantitate INT,
    PRIMARY KEY (ComandaID, ProdusID),
    FOREIGN KEY (ComandaID) REFERENCES Comenzi(ComandaID),
    FOREIGN KEY (ProdusID) REFERENCES Produse(ProdusID)
);

INSERT INTO Persoane (PersoanaID, Nume, Adresa) 
VALUES (1, 'John Doe', 'Strada ABC'),
       (2, 'Alice Smith', 'Strada XYZ'),
       (3, 'Bob Johnson', 'Strada PQR'),
       (4, 'Eve Brown', 'Strada LMN');

INSERT INTO Comenzi (ComandaID, Descriere, PersoanaID) 
VALUES (101, 'Comanda 1', 1),
       (102, 'Comanda 2', 2),
       (103, 'Comanda 3', 3),
       (104, 'Comanda 4', 3);

INSERT INTO Produse (ProdusID, NumeProdus, Pret) 
VALUES (201, 'Produs A', 10.99),
       (202, 'Produs B', 15.99),
       (203, 'Produs C', 8.99),
       (204, 'Produs D', 12.99),
       (205, 'Produs E', 19.99);

INSERT INTO ComenziProduse (ComandaID, ProdusID, Cantitate) 
VALUES (101, 201, 2),
       (101, 202, 1),
       (102, 203, 3),
       (102, 204, 2),
       (103, 204, 1),
       (103, 205, 2),
       (104, 203, 1);

ALTER TABLE Persoane 
ADD DataAdaugarii DATETIME DEFAULT GETDATE(),
    DataUltimeiModificari DATETIME DEFAULT GETDATE();

ALTER TABLE Comenzi
ADD DataAdaugarii DATETIME DEFAULT GETDATE(),
    DataUltimeiModificari DATETIME DEFAULT GETDATE();

ALTER TABLE Produse
ADD DataAdaugarii DATETIME DEFAULT GETDATE(),
    DataUltimeiModificari DATETIME DEFAULT GETDATE();

ALTER TABLE ComenziProduse
ADD DataAdaugarii DATETIME DEFAULT GETDATE(),
    DataUltimeiModificari DATETIME DEFAULT GETDATE();

CREATE INDEX ComenziProduse_ComandaID_Index ON ComenziProduse (ComandaID);

-- suma totala a preturilor produselor din fiecare comanda pentru toate comenzile
SELECT c.ComandaID, SUM(p.Pret * cp.Cantitate) AS Total FROM Comenzi c
Join ComenziProduse cp ON c.ComandaID = cp.ComandaID
JOIN Produse p ON cp.ProdusID = p.ProdusID
GROUP BY c.ComandaID
HAVING COUNT(cp.ProdusID) >= 2;

CREATE INDEX Comenzi_PersoanaID_Index ON Comenzi (PersoanaID);

-- persoanele care au plasat comenzi si data cea mai recenta a comandei plasate de fiecare persoana
SELECT p.PersoanaID, p.Nume, MAX(c.DataAdaugarii) AS DataUltimeiComenzi
FROM Persoane p
LEFT JOIN Comenzi c ON p.PersoanaID = c.PersoanaID
GROUP BY p.PersoanaID, p.Nume;