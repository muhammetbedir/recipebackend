using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Recipe.Common.Helpers
{
    public static class GetTokenHelper
    {
        public static JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: ConfigurationHelper.config["JWT:ValidIssuer"],
                audience: ConfigurationHelper.config["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
