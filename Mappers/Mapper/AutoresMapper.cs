using Nx.Domain.Travel;
using Nx.Dto.Travel;
using Nx.Mapper.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Nx.Mapper
{
    public class AutoresMapper : IAutorMapper
    {
        public Autores MapearAutor(AutorDto req)
        {
            return new Autores
            {
                Nombre = req.Nombre,
                AutorId = req.AutorId,
                Ciudad = req.Ciudad,
                Email = req.Email,
                FechaNacimiento = req.FechaNacimiento
            };
        }

        public AutorDto MapearAutorDto(Autores req)
        {
            return new AutorDto
            {
                Nombre = req.Nombre,
                AutorId = req.AutorId,
                Ciudad = req.Ciudad,
                Email = req.Email,
                FechaNacimiento = req.FechaNacimiento
            };
        }

        public List<Autores> MapearAutores(List<AutorDto> req)
        {
            return req.Select(t=> MapearAutor(t)).ToList();
        }

        public List<AutorDto> MapearAutoresDto(List<Autores> req)
        {
            return req.Select(t => MapearAutorDto(t)).ToList();
        }
    }
}
