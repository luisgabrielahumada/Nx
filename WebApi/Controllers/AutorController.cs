using Nx.Dto.Common;
using Nx.Dto.Travel;
using Nx.Services.Interface;
using Core.Component.Library.PagerRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Helper;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/Autores")]
    public class AutorController : ControllerBase
    {
        private readonly IAutor _process;
        public AutorController(IAutor process)
        {
            _process = process;
        }

        [HttpPost]
        [Route("Listar")]
        public HttpMessage<WebPagerRecord<AutorDto>> Listar(PaginationDto req)
        {

            var resp = _process.Listar(req);

            return new HttpMessage<WebPagerRecord<AutorDto>>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPost]
        [Route("Crear")]
        public HttpMessage<int> Crear(AutorDto req)
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
        public HttpMessage<int> Actualizar(int id, AutorDto req)
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
        public HttpMessage<AutorDto> Obtener(int id)
        {
            var resp = _process.Obtener(id);

            return new HttpMessage<AutorDto>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }
    }
}
