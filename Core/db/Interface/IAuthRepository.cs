using Common.Infrastructure;
using Nx.Domain.Auth;
using Nx.Dto.Auth;

namespace Nx.Repository.Interface
{
    public interface IAuthRepository
    {
        TokenDto Login(User req);
    }
}
