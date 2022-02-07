using Nx.Domain.Travel;
using Nx.Dto.Common;
using System.Collections.Generic;

namespace Nx.Repository.Interface
{
    public interface ILibroRepository
    {
        List<Libro> Listar(PaginationDto req);
        int Create(Libro req);
        int Actualizar(int id, Libro req);
        void Delete(int id);
        Libro Obtener(int id);
        int ContarRegistos();
    }
}
