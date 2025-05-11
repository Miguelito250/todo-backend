using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace todo_backend.Utils.JWT
{
    public class OptionsToken
    {
        public string Key { get; }

        public TokenValidationParameters Options { get; }

        public OptionsToken()
        {
            Key = "AJSDAKSDAMIMADLWIENALDSawdns1372w";
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
