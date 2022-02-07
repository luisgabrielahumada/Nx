using Common.Infrastructure;
using Core.Component.Library.SQL;
using Nx.Domain.Travel;
using Nx.Dto.Common;
using Nx.Repository;
using Nx.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Nx.Services
{
    public class EditorialRepository : IEditorialRepository
    {
        readonly AppDatabase db;
        Settings _settings;
        public EditorialRepository(Settings settings)
        {
            _settings = settings;
            db = new AppDatabase(settings.ConnectionStrings.ConnectionString);
        }
        public List<Editoriales> Listar(PaginationDto req)
        {
            var data = new Execute(db, "DB_Lista_Editoriales",
                                  new
                                  {
                                      pageIndex = req.PaginaActual,
                                      pageSize = req.CantidadPaginas,
                                  })
                                  .Procedure<Editoriales>()
                                  .ToList();
            return data;
        }
        public int Create(Editoriales req)
        {
            return new Execute(db, "DB_Guardar_Editorial",
                                     new
                                     {
                                         Direccion = req.Direccion,
                                         Email = req.Email,
                                         MaximoRegistradosLibros = req.MaximoRegistradosLibros,
                                         Nombre = req.Nombre,
                                         Telefono = req.Telefono
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public int Actualizar(int id, Editoriales req)
        {
           return new Execute(db, "DB_Guardar_Editorial",
                                     new
                                     {
                                         EditorialId = id,
                                         Direccion = req.Direccion,
                                         Email = req.Email,
                                         MaximoRegistradosLibros = req.MaximoRegistradosLibros,
                                         Nombre = req.Nombre,
                                         Telefono = req.Telefono
                                     })
                                     .Procedure<int>()
                                     .FirstOrDefault();
        }
        public void Delete(int id)
        {
            new Execute(db, "DB_Delete_Editorial",
                                    new
                                    {
                                        EditorialId = id,
                                    })
                                    .Procedure<int>()
                                    .FirstOrDefault();
        }
        public Editoriales Obtener(int id)
        {
           return new Execute(db, "DB_Obtener_Editorial",
                                    new
                                    {
                                        EditorialId = id,
                                    })
                                    .Procedure<Editoriales>()
                                    .FirstOrDefault();
        }
        public int ContarRegistos()
        {
            var data = new Execute(db, "DB_ContarRegistos_Editorial",
                                 new
                                 {
                                 })
                                 .Procedure<int>()
                                 .FirstOrDefault();
            return data;
        }
    }
}