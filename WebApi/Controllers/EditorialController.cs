using Core.Component.Library.PagerRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nx.Dto.Common;
using Nx.Dto.Travel;
using Nx.Services.Interface;
using System.Net;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/Editoriales")]
    public class EditorialController : ControllerBase
    {
        private readonly IEditorial _process;
        public EditorialController(IEditorial process)
        {
            _process = process;
        }

        [HttpPost]
        [Route("Listar")]
        public HttpMessage<WebPagerRecord<EditorialDto>> Listar(PaginationDto req)
        {

            var resp = _process.Listar(req);

            return new HttpMessage<WebPagerRecord<EditorialDto>>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPost]
        [Route("Crear")]
        public HttpMessage<int> Crear(EditorialDto req)
        {
            var resp = _process.Crear(req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.Created,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPut]
        [Route("{id}")]
        public HttpMessage<int> Actualizar(int id, EditorialDto req)
        {
            var data = _process.Actualizar(id, req);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data= data
            };
        }

        [HttpDelete]
        [Route("{id}/Eliminar")]
        public HttpMessage<int> Eliminar(int id)
        {

            _process.Eliminar(id);

            return new HttpMessage<int>
            {
                StatusCode = HttpStatusCode.Created,
                IsSuccess = true
            };
        }

        [HttpPatch]
        [Route("{id}/Obtener")]
        public HttpMessage<EditorialDto> Obtener(int id)
        {
            var resp = _process.Obtener(id);

            return new HttpMessage<EditorialDto>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }
    }
}
