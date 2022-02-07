using Nx.Domain.Travel;
using Nx.Dto.Travel;
using System.Collections.Generic;

namespace Nx.Mapper.Interface
{
    public interface IEditorialMapper
    {
        Editoriales MapearEditorial(EditorialDto req);
        EditorialDto MapearEditorialDto(Editoriales req);
        List<EditorialDto> MapearEditorialesDto(List<Editoriales> req);
        List<Editoriales> MapearEditoriales(List<EditorialDto> req);
    }
}
