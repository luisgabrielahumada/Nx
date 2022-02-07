namespace Nx.Domain.Travel
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public int NumerosPaginas { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public int EditorialId { get; set; }
        public int AutorId { get; set; }
    }
}
