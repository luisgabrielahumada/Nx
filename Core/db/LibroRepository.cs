using Nx.Domain.Travel;
using Nx.Dto.Common;
using Nx.Repository;
using Nx.Repository.Interface;
using Common.Infrastructure;
using Core.Component.Library.SQL;
using System.Collections.Generic;
using System.Linq;

namespace Nx.Services
{
    public class LibroRepository : ILibroRepository
    {
        readonly AppDatabase db;
        Settings _settings;
        public LibroRepository(Settings settings)
        {
            _settings = settings;
            db = new AppDatabase(settings.ConnectionStrings.ConnectionString);
        }
        public List<Libro> Listar(PaginationDto req)
        {
            var data = new Execute(db, "DB_Lista_Libros",
                                  new
                                  {
                                      pageIndex = req.PaginaActual,
                                      pageSize = req.CantidadPaginas,
                                  })
                                  .Procedure<Libro>()
                                  .ToList();
            return data;
        }
        public int Create(Libro req)
        {
            return new Execute(db, "DB_Guardar_Libro",
                                     new
                                     {
                                         Titulo = req.Titulo,
                                         Año = req.Año,
                                         Ciudad = req.Ciudad,
                                         EditorialId = req.EditorialId,
                                         Email = req.Email,
                                         Genero = req.Genero,
                                         NumerosPaginas = req.NumerosPaginas
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public int Actualizar(int id, Libro req)
        {
           return new Execute(db, "DB_Guardar_Libro",
                                     new
                                     {
                                         LibroId = id,
                                         Titulo = req.Titulo,
                                         Año = req.Año,
                                         Ciudad = req.Ciudad,
                                         EditorialId = req.EditorialId,
                                         Email = req.Email,
                                         Genero = req.Genero,
                                         NumerosPaginas = req.NumerosPaginas
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public void Delete(int id)
        {
            new Execute(db, "DB_Delete_Libro",
                                    new
                                    {
                                        LibroId = id,
                                    })
                                    .Procedure<int>()
                                    .FirstOrDefault();
        }
        public Libro Obtener(int id)
        {
           return new Execute(db, "DB_Obtener_Libro",
                                    new
                                    {
                                        LibroId = id,
                                    })
                                    .Procedure<Libro>()
                                    .FirstOrDefault();
        }
        public int ContarRegistos()
        {
            var data = new Execute(db, "DB_ContarRegistos_libro",
                                 new
                                 {
                                 })
                                 .Procedure<int>()
                                 .FirstOrDefault();
            return data;
        }
    }
}