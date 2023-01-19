using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Queries.User.Services
{
    public interface ITokenService
    {
        string CreateToken(string email, string role);
    }
}
