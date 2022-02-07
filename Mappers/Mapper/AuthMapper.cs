using Nx.Domain.Auth;
using Nx.Dto.Auth;
using Nx.Mapper.Interface;

namespace Nx.Mapper
{
    public class AuthMapper : IAuthMapper
    {
        public TokenDto MapearTokenDto(User req)
        {
            var token = new TokenDto
            {
                Email = req.Email,
                Login = req.Login,
                Name = req.Name,
                 UserId= req.IdUser
            };

            return token;
        }

        public User MapearUser(UserDto req)
        {
            var user = new User
            {
                Login = req.Login,
                Password = req.Password
            };
            return user;
        }
    }
}
