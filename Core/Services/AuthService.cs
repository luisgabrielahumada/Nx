using Common.Infrastructure;
using System;
using Nx.Dto.Auth;
using Nx.Mapper.Interface;
using Nx.Repository.Interface;
using Nx.Services.Interface;

namespace Nx.Services
{
    public class AuthService : IAuth
    {
        public IAuthRepository _db;
        public readonly Settings _settings;
        public readonly IAuthMapper _map;
        public AuthService(IAuthMapper map, IAuthRepository db)
        {
            _map = map;
            _db = db;
        }
        public TokenDto Signin(UserDto req)
        {
            var user  = _map.MapearUser(req);
            // Access to the database.
            var resp = _db.Login(user);
           
            return resp;
        }
    }
}
