namespace Nx.Dto.Travel
{
    public class LibroDto
    {
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public int NumerosPaginas { get; set; }
        public string Ciudad { get; set; }
        public string Email { get; set; }
        public EditorialDto Editorial { get; set; }
        public AutorDto Autor { get; set; }
    }
}
