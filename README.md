Script para o Banco de Dados SQL Server:

/*Nome do Banco de dados: superheroes*/

CREATE TABLE Herois (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    Nome NVARCHAR(120),
    NomeHeroi NVARCHAR(120) UNIQUE NOT NULL,
    DataNascimento DATETIME2 NOT NULL,
    Altura FLOAT,
    Peso FLOAT
);
GO
CREATE TABLE SuperPoderes (
    Id INT PRIMARY KEY IDENTITY(1, 1),
    SuperPoder NVARCHAR(50),
    Descricao NVARCHAR(250) NOT NULL
);
GO
CREATE TABLE HeroisSuperpoderes (
    HeroiId INT,
    SuperPoderId INT,
    FOREIGN KEY (HeroiId) REFERENCES Herois(Id),
    FOREIGN KEY (SuperPoderId) REFERENCES SuperPoderes(Id),
    PRIMARY KEY (HeroiId, SuperPoderId)
);
GO

INSERT INTO Superpoderes (Superpoder, Descricao) VALUES 
('Poder 1', 'Poder 1 - Descrição'),
('Poder 2', 'Poder 2 - Descrição'),
('Poder 3', 'Poder 3 - Descrição')
GO
