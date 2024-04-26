using System.Threading.Tasks;
using Restro.Models;

namespace Restro.Repositories
{
    public interface ILoginRepository
    {
        Task<Login> GetLoginByEmailAsync(string email);
    }
}
