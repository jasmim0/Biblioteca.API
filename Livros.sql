CREATE TABLE Livros (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Titulo VARCHAR(255) NOT NULL,
    Autor VARCHAR(255) NOT NULL,
    AnoPublicacao INT,
    Genero VARCHAR(100),
    Disponivel BOOLEAN DEFAULT TRUE
)