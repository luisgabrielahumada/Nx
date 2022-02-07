using Core.Component.Library.PagerRecord;
using Nx.Dto.Travel;
using Nx.Dto.Common;

namespace Nx.Services.Interface
{
    public interface IAutor
    {
        WebPagerRecord<AutorDto> Listar(PaginationDto req);
        int Crear(AutorDto req);
        AutorDto Obtener(int id);
        int Actualizar(int id, AutorDto req);
        void Eliminar(int id);
    }
}
