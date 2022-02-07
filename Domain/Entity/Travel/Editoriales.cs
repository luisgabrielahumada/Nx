using System.Collections.Generic;

namespace Nx.Domain.Travel
{
    public class Editoriales
    {
        public int EditorialId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int MaximoRegistradosLibros { get; set; }
    }
}
