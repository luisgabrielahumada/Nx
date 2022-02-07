using Nx.Domain.Travel;
using Nx.Dto.Travel;
using Nx.Mapper.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Nx.Mapper
{
    public class LibroMapper : ILibroMapper
    {
        public LibroDto MapearLibroDto(Libro req)
        {
            return new LibroDto
            {
                Autor = new AutorDto
                {
                    AutorId = req.AutorId
                },
                Año = req.Año,
                Ciudad = req.Ciudad,
                Editorial = new EditorialDto
                {
                    EditorialId = req.EditorialId
                },
                Email = req.Email,
                Genero = req.Genero,
                LibroId = req.LibroId,
                NumerosPaginas = req.NumerosPaginas,
                Titulo = req.Titulo
            };
        }

        public Libro MapearLibros(LibroDto req)
        {
            return new Libro
            {
                AutorId = req.Autor.AutorId,
                Año = req.Año,
                Ciudad = req.Ciudad,
                EditorialId = req.Editorial.EditorialId,
                Email = req.Email,
                Genero = req.Genero,
                LibroId = req.LibroId,
                NumerosPaginas = req.NumerosPaginas,
                Titulo = req.Titulo
            };
        }

        public List<Libro> MapearLibros(List<LibroDto> req)
        {
            return req.Select(m => MapearLibros(m)).ToList();
        }

        public List<LibroDto> MapearLibrosDto(List<Libro> req)
        {
            return req.Select(m => MapearLibroDto(m)).ToList();
        }
    }
}
