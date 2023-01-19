using Base30.Authentication.Domain;
using Base30.Core.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Application.Queries.User.Services
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;
        private readonly IAspNetUsersRepository _aspnetusersRepository;

        public TokenService(IConfiguration configuration, IAspNetUsersRepository aspnetusersRepository)
        {
            _configuration = configuration;
            _aspnetusersRepository = aspnetusersRepository;
        }

        public string CreateToken(string email, string role)
        {
            IdentityUser<Guid>? user = _aspnetusersRepository.GetUserByEmail(email);

            Claim[] userClaim = new Claim[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id.ToString())
            };

            //https://jwt.io/
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SymmetricSecurityKey"))
                );

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: userClaim,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenstring = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenstring;
        }
    }
}
