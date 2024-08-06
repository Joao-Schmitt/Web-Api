using Microsoft.IdentityModel.Tokens;
using Gear.Domain.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace Gear.WebApi.Plataform.Security
{
    public class JwtService
    {
        public string GenerateUsuarioToken(UsersCredentials usuario, string tpUsuario)
        {
            var claims = GetUsuarioClaimsIdentity(usuario, tpUsuario);
            return GenerateToken(claims);
        }

        private string GenerateToken(ClaimsIdentity claims)
        {
            var symmetricKey = new SymmetricSecurityKey(JwtSettings.SigningKey);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = JwtSettings.Issuer,
                Audience = JwtSettings.Audience,
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature)
            });

            return handler.WriteToken(securityToken);
        }

        private ClaimsIdentity GetUsuarioClaimsIdentity(UsersCredentials usuario, string tpUsuario)
        {
            return new ClaimsIdentity
            (
                new GenericIdentity($"{usuario.Id}-{usuario.Email}"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("email", usuario.Email)
                }
            ) ;
        }
    }

    public class JwtSettings
    {
        public static string Issuer => "gear";
        public static string Audience => "gear";

        public static byte[] SigningKey = Encoding.UTF8.GetBytes("6707870a-eeea-4a46-be83-e580e4e32431");
    }


}
