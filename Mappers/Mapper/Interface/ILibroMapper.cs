using Nx.Domain.Travel;
using Nx.Dto.Travel;
using System.Collections.Generic;

namespace Nx.Mapper.Interface
{
    public interface ILibroMapper
    {
        Libro MapearLibros(LibroDto req);
        LibroDto MapearLibroDto(Libro req);
        List<LibroDto> MapearLibrosDto(List<Libro> req);
        List<Libro> MapearLibros(List<LibroDto> req);
    }
}
