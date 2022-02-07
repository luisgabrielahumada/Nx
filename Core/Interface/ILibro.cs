using Core.Component.Library.PagerRecord;
using Nx.Dto.Travel;
using Nx.Dto.Common;

namespace Nx.Services.Interface
{
    public interface ILibro
    {
        WebPagerRecord<LibroDto> Listar(PaginationDto req);
        int Crear(LibroDto req);
        LibroDto Obtener(int id);
        int Actualizar(int id, LibroDto req);
        void Eliminar(int id);
    }
}
