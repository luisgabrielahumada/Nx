using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Helper;
using Nx.Dto.Auth;
using Nx.Services.Interface;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/Auth/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuth _process;
        public AuthController(IAuth process)
        {
            _process = process;
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpMessage<TokenDto> Signin(UserDto req)
        {
            var resp = _process.Signin(req);
            return new HttpMessage<TokenDto>
            {
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true,
                Data = resp
            };
        }
    }
}
