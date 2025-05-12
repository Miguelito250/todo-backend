using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace todo_backend.Utils.JWT
{
    /// <summary>
    /// Esta clase es la exporta todo lo que se va a validar de los tokens,
    /// se establece la misma Key aca para ejemplos de practicidad y configuraciones basicas de 
    /// esta misma clase
    public class OptionsToken
    {
        public string Key { get; }

        public TokenValidationParameters Options { get; }

        public OptionsToken()
        {
            Key = "LhWEv33EHTGmvFWYPazfi464C5hU62MOj";
            Options = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
            }; ;
        }
    }
}
