namespace Biblioteca.API.Models
{
    public class Livros
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnoPublicacao { get; set; }
        public string Genero { get; set; }
        public bool Disponivel { get; set; }
        public object Livro { get; set; }   
    }
}
