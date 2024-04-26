using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Data;
using Microsoft.EntityFrameworkCore;
using Restro.Models;
using Restro.Repositories;

namespace Restro.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly RestroDbContext _context;

        public MenuItemRepository(RestroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuItem>> GetAllMenuItemsAsync()
        {
            return await _context.MenuItems.Include(m => m.Menu).ToListAsync();
        }

        public async Task<MenuItem> GetMenuItemByIdAsync(int id)
        {
            return await _context.MenuItems.Include(m => m.Menu).FirstOrDefaultAsync(m => m.MenuItemId == id);
        }

        public async Task<MenuItem> CreateMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return menuItem;
        }

        public async Task UpdateMenuItemAsync(MenuItem menuItem)
        {
            _context.Entry(menuItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItemAsync(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }
    }
}

