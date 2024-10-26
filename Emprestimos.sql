CREATE TABLE Emprestimos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    LivroId INT,
    UsuarioId INT,
    DataEmprestimo DATE,
    DataDevolucao DATE,
    FOREIGN KEY (LivroId) REFERENCES Livros(Id),
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
)