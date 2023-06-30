using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project_X.Domain.Entities;
using Project_X.Domain.Enums;
using Project_X.Interface.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_X.Sevice.Services
{
    public  class TokenService: ITokenService
    {

        private  readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public  string GerarToken(string email, List<int> roles)
        {
            int cont = 1;
            var r = string.Empty;
            foreach (var role in roles) 
            {
                if (roles.Count == cont) { r += role; }
                else { r += role + ","; }
                cont++;
            
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_configuration["keyToken"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, email), // .Tostring   User.Identity.Name
                    new Claim(ClaimTypes.Role, r)   // User.IsInRole
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        public  string getJWTTokenClaim(string token)
        {
            var t = token.Split(" ");
            string role = "name";
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(t[1]);
                var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == role)?.Value;
                return claimValue;
            }
            catch (Exception)
            {
                //TODO: Logger.Error
                return null;
            }
        }
    }

}
