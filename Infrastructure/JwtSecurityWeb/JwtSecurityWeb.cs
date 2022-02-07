using Common.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Nx.Dto.Auth;

namespace JwtSecurity
{
    public class JwtSecurityWeb
    {
        public string GenerateJSONWebToken(TokenDto data, Settings settings)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var TrasactionDate = DateTime.Now;
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, data.SessionId),
                new Claim(JwtRegisteredClaimNames.Name, data.Name),
                new Claim(JwtRegisteredClaimNames.Email, data.Email),
                new Claim(JwtRegisteredClaimNames.Iat, TrasactionDate.Ticks.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, data.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var reqToken = new JwtSecurityToken(
                settings.Jwt.Issuer,
                settings.Jwt.Issuer,
                claims,
                expires: DateTime.Now.AddMinutes(settings.Jwt.Expires),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(reqToken);
            return token;
        }
    }
}
