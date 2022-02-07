using Nx.Dto.Auth;

namespace Nx.Services.Interface
{
    public interface IAuth
    {
        TokenDto Signin(UserDto req);
    }
}
