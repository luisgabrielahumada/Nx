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
    public class LibroService : ILibro
    {
        public ILibroRepository db;
        public readonly Settings _settings;
        public readonly ILibroMapper _map;
        public ILibroRepository _db;
        public LibroService(ILibroMapper map, ILibroRepository db, Settings settings)
        {
            _map = map;
            _db = db;
            _settings = settings;
        }
        public WebPagerRecord<LibroDto> Listar(PaginationDto req)
        {
            // Access to the database.
            var data = _db.Listar(req);
            var dataDto = _map.MapearLibrosDto(data);
            var totalRecords = _db.ContarRegistos();
            return new WebPagerRecord<LibroDto>(list: dataDto, page: req.PaginaActual, pageSize: req.CantidadPaginas, allItemsCount: totalRecords);
        }
        public int Crear(LibroDto req)
        {
            if (string.IsNullOrEmpty(req.Titulo))
                throw new Exception("El titulo del libro es requerido");

            var resp = _map.MapearLibros(req);
            // Access to the database.
            return _db.Create(resp);
        }
        public int Actualizar(int id, LibroDto req)
        {

            if (string.IsNullOrEmpty(req.Titulo))
                throw new Exception("El titulo del libro es requerido");

            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");


            var resp = _map.MapearLibros(req);
            // Access to the database.
            return _db.Actualizar(id, resp);
        }
        public void Eliminar(int id)
        {
            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");
            _db.Delete(id);
        }
        public LibroDto Obtener(int id)
        {
            if (id == 0)
                throw new Exception("El Id tiene que ser mayor que cero");

            var req = _db.Obtener(id);
           return _map.MapearLibroDto(req);
        }
    }
}
