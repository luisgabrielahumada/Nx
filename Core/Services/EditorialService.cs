using Nx.Dto.Common;
using Nx.Dto.Travel;
using Nx.Mapper.Interface;
using Nx.Repository.Interface;
using Nx.Services.Interface;
using Common.Infrastructure;
using Core.Component.Library.PagerRecord;
using System;

namespace Nx.Services
{
    public class EditorialService : IEditorial
    {
        public IEditorialRepository db;
        public readonly Settings _settings;
        public readonly IEditorialMapper _map;
        public IEditorialRepository _db;
        public EditorialService(IEditorialMapper map, IEditorialRepository db, Settings settings)
        {
            _map = map;
            _db = db;
            _settings = settings;
        }
        public WebPagerRecord<EditorialDto> Listar(PaginationDto req)
        {
            // Access to the database.
            var data = _db.Listar(req);
            var dataDto = _map.MapearEditorialesDto(data);
            var totalRecords = _db.ContarRegistos();
            return new WebPagerRecord<EditorialDto>(list: dataDto, page: req.PaginaActual, pageSize: req.CantidadPaginas, allItemsCount: totalRecords);
        }
        public int Crear(EditorialDto req)
        {
            if (string.IsNullOrEmpty(req.Nombre))
                throw new Exception("El nombre del autor es requerido");

            var resp = _map.MapearEditorial(req);
            // Access to the database.
            return _db.Create(resp);
        }
        public int Actualizar(int id, EditorialDto req)
        {

            if (string.IsNullOrEmpty(req.Nombre))
                throw new Exception("El nombre del autor es requerido");

            if (id == 0)
                throw new Exception("El id tiene que ser mayor que cero");


            var resp = _map.MapearEditorial(req);
            // Access to the database.
            return _db.Actualizar(id, resp);
        }
        public void Eliminar(int id)
        {
            if (id == 0)
                throw new Exception("El id tiene que ser mayor que cero");
            _db.Delete(id);
        }
        public EditorialDto Obtener(int id)
        {
            if (id == 0)
                throw new Exception("El id tiene que ser mayor que cero");

            var req = _db.Obtener(id);
           return _map.MapearEditorialDto(req);
        }
    }
}
