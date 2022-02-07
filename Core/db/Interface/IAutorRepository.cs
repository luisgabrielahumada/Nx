using Nx.Domain.Travel;
using Nx.Dto.Common;
using System.Collections.Generic;

namespace Nx.Repository.Interface
{
    public interface IAutorRepository
    {
        List<Autores> Listar(PaginationDto req);
        int Create(Autores req);
        int Actualizar(int id, Autores req);
        void Delete(int id);
        Autores Obtener(int id);
        int ContarRegistos();
    }
}
