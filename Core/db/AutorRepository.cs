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
    public class AutorRepository : IAutorRepository
    {
        readonly AppDatabase db;
        Settings _settings;
        public AutorRepository(Settings settings)
        {
            _settings = settings;
            db = new AppDatabase(settings.ConnectionStrings.ConnectionString);
        }
        public List<Autores> Listar(PaginationDto req)
        {
            var data = new Execute(db, "DB_Lista_Autores",
                                  new
                                  {
                                      pageIndex = req.PaginaActual,
                                      pageSize = req.CantidadPaginas,
                                  })
                                  .Procedure<Autores>()
                                  .ToList();
            return data;
        }
        public int Create(Autores req)
        {
            return new Execute(db, "DB_Guardar_Autor",
                                     new
                                     {
                                         Ciudad = req.Ciudad,
                                         Email = req.Email,
                                         FechaNacimiento = req.FechaNacimiento,
                                         Nombre = req.Nombre
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public int Actualizar(int id, Autores req)
        {
           return new Execute(db, "DB_Guardar_Autor",
                                     new
                                     {
                                         AutorId = id,
                                         Ciudad = req.Ciudad,
                                         Email = req.Email,
                                         FechaNacimiento = req.FechaNacimiento,
                                         Nombre = req.Nombre
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public void Delete(int id)
        {
            new Execute(db, "DB_Delete_Autor",
                                    new
                                    {
                                        AutorId = id,
                                    })
                                    .Procedure<int>()
                                    .FirstOrDefault();
        }
        public Autores Obtener(int id)
        {
           return new Execute(db, "DB_Obtener_Autor",
                                    new
                                    {
                                        AutorId = id,
                                    })
                                    .Procedure<Autores>()
                                    .FirstOrDefault();
        }
        public int ContarRegistos()
        {
            var data = new Execute(db, "DB_ContarRegistos_Autor",
                                 new
                                 {
                                 })
                                 .Procedure<int>()
                                 .FirstOrDefault();
            return data;
        }
    }
}