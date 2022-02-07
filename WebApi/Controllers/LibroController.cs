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
    [Route("api/v1/Libros")]
    public class LibroController : ControllerBase
    {
        private readonly ILibro _process;
        public LibroController(ILibro process)
        {
            _process = process;
        }

        [HttpPost]
        [Route("Listar")]
        public HttpMessage<WebPagerRecord<LibroDto>> Listar(PaginationDto req)
        {

            var resp = _process.Listar(req);

            return new HttpMessage<WebPagerRecord<LibroDto>>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }

        [HttpPost]
        [Route("Crear")]
        public HttpMessage<int> Crear(LibroDto req)
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
        public HttpMessage<int> Actualizar(int id, LibroDto req)
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
        public HttpMessage<LibroDto> Obtener(int id)
        {
            var resp = _process.Obtener(id);

            return new HttpMessage<LibroDto>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }
    }
}
