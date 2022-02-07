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
    public class AutorService : IAutor
    {
        public IAutorRepository db;
        public readonly Settings _settings;
        public readonly IAutorMapper _map;
        public IAutorRepository _db;
        public AutorService(IAutorMapper map, IAutorRepository db, Settings settings)
        {
            _map = map;
            _db = db;
            _settings = settings;
        }
        public WebPagerRecord<AutorDto> Listar(PaginationDto req)
        {
            // Access to the database.
            var data = _db.Listar(req);
            var dataDto = _map.MapearAutoresDto(data);
            var totalRecords = _db.ContarRegistos();
            return new WebPagerRecord<AutorDto>(list: dataDto, page: req.PaginaActual, pageSize: req.CantidadPaginas, allItemsCount: totalRecords);
        }
        public int Crear(AutorDto req)
        {
            if (string.IsNullOrEmpty(req.Nombre))
                throw new Exception("El nombre del autor es requerido");

            var resp = _map.MapearAutor(req);
            // Access to the database.
            return _db.Create(resp);
        }
        public int Actualizar(int id, AutorDto req)
        {

            if (string.IsNullOrEmpty(req.Nombre))
                throw new Exception("El nombre del autor es requerido");

            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");


            var resp = _map.MapearAutor(req);
            // Access to the database.
            return _db.Actualizar(id, resp);
        }
        public void Eliminar(int id)
        {
            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");
            _db.Delete(id);
        }
        public AutorDto Obtener(int id)
        {
            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");

            var req = _db.Obtener(id);
           return _map.MapearAutorDto(req);
        }
    }
}
