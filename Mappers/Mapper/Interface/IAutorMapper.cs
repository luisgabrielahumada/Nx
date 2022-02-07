using Nx.Domain.Travel;
using Nx.Dto.Travel;
using System.Collections.Generic;

namespace Nx.Mapper.Interface
{
    public interface IAutorMapper
    {
        Autores MapearAutor(AutorDto req);
        AutorDto MapearAutorDto(Autores req);
        List<AutorDto> MapearAutoresDto(List<Autores> req);
        List<Autores> MapearAutores(List<AutorDto> req);
    }
}
