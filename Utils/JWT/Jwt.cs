using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace todo_backend.Utils.JWT
{
    public class Jwt
    {
        private readonly OptionsToken _OptiosToken;
        public Jwt(OptionsToken optionsToken)
        {
            _OptiosToken = optionsToken;
        }
        public string GenerateToken(Claim[] claimsIdentity, int minutesToExpire)
        {
            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_OptiosToken.Key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                null,
                null,
                claims: claimsIdentity,
                expires: DateTime.Now.AddMinutes(minutesToExpire),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
