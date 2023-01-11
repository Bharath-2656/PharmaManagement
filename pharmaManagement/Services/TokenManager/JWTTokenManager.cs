using System;
using Microsoft.IdentityModel.Tokens;
using pharmaManagement.Services.TokenManager;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using pharmaManagement.Modals;

namespace pharmaManagement.Services.TokenManager
{

    public class JWTTokenManager : IJWTTokenManager
    {
        private readonly IConfiguration _configuration;
        public JWTTokenManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Tokens Authenticate(string EmailId, string Role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Email,EmailId),
                    new Claim(ClaimTypes.Role,Role)
            }
            ),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}