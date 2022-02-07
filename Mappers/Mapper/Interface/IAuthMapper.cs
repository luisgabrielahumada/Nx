using Nx.Domain.Auth;
using Nx.Dto.Auth;

namespace Nx.Mapper.Interface
{
    public interface IAuthMapper
    {
        User MapearUser(UserDto req);
        TokenDto MapearTokenDto(User req);
    }
}
