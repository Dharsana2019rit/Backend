using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Restro.Models;

namespace Restro.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAdmin(Login admin);
        Task<string> RegisterUser(Login user);
        Task<string> AdminLogin(Login admin);
        Task<string> UserLogin(Login user);
        Task<string?> AuthenticateAsync(HttpContext httpContext, string? cookieToken = null);
    }
}