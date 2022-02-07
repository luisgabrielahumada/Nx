using Core.Component.Library.PagerRecord;
using Nx.Dto.Travel;
using Nx.Dto.Common;

namespace Nx.Services.Interface
{
    public interface IEditorial
    {
        WebPagerRecord<EditorialDto> Listar(PaginationDto req);
        int Crear(EditorialDto req);
        EditorialDto Obtener(int id);
        int Actualizar(int id, EditorialDto req);
        void Eliminar(int id);
    }
}
