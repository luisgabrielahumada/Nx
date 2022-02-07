using Nx.Domain.Travel;
using Nx.Dto.Common;
using System.Collections.Generic;

namespace Nx.Repository.Interface
{
    public interface IEditorialRepository
    {
        List<Editoriales> Listar(PaginationDto req);
        int Create(Editoriales req);
        int Actualizar(int id, Editoriales req);
        void Delete(int id);
        Editoriales Obtener(int id);
        int ContarRegistos();
    }
}
