using agroWebSitreAPI.Domain.Model.UserAggregate;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace agroWebSitreAPI.Application.Services
{
    public class TokenService
    {
        public static object GenerateToken(User user)
        {
            //Trago minha Chave de crypto
            var key = Encoding.ASCII.GetBytes(Key.Secret);
            //Configuraçao do payload
            var tokenConfig = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //instancio o JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            //Gero o Token
            var token = tokenHandler.CreateToken(tokenConfig);
            //Tranforma em String
            var tokenString = tokenHandler.WriteToken(token);

            //Retorna objeto com token
            return new { tokenString };

        }
    }
}
