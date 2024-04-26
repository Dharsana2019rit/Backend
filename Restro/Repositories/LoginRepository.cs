using System.Threading.Tasks;
using Restro.Data;
using Restro.Models;
using Microsoft.EntityFrameworkCore;

namespace Restro.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly RestroDbContext _context;

        public LoginRepository(RestroDbContext context)
        {
            _context = context;
        }

        public async Task<Login> GetLoginByEmailAsync(string email)
        {
            return await _context.Logins.FirstOrDefaultAsync(x => x.EmailId == email);
        }
    }
}

