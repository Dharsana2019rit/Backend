using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Models;

namespace Restro.Repositories
{
    public interface IMenuRepository
    {
        Task<IEnumerable<Menu>> GetAllMenusAsync();
        Task<Menu> GetMenuByIdAsync(int id);
        Task<Menu> CreateMenuAsync(Menu menu);
        Task UpdateMenuAsync(Menu menu);
        Task DeleteMenuAsync(Menu menu);
    }
}

