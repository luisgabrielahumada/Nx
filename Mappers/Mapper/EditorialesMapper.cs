using Nx.Domain.Travel;
using Nx.Dto.Travel;
using Nx.Mapper.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Nx.Mapper
{
    public class EditorialesMapper : IEditorialMapper
    {
        public Editoriales MapearEditorial(EditorialDto req)
        {
            return new Editoriales
            {
                Direccion = req.Direccion,
                EditorialId = req.EditorialId,
                Email = req.Email,
                MaximoRegistradosLibros = req.MaximoRegistradosLibros,
                Nombre = req.Nombre,
                Telefono = req.Telefono
            };
        }

        public EditorialDto MapearEditorialDto(Editoriales req)
        {
            return new EditorialDto
            {
                Direccion = req.Direccion,
                EditorialId = req.EditorialId,
                Email = req.Email,
                MaximoRegistradosLibros = req.MaximoRegistradosLibros,
                Nombre = req.Nombre,
                Telefono = req.Telefono
            };
        }

        public List<Editoriales> MapearEditoriales(List<EditorialDto> req)
        {
            return req.Select(m => MapearEditorial(m)).ToList();
        }

        public List<EditorialDto> MapearEditorialesDto(List<Editoriales> req)
        {
            return req.Select(m => MapearEditorialDto(m)).ToList();
        }
    }
}
