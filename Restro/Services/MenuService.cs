using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Models;
using Restro.Repositories;
using Restro.Services;

namespace Restro.Services
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<IEnumerable<Menu>> GetAllMenusAsync()
        {
            return await _menuRepository.GetAllMenusAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            return await _menuRepository.GetMenuByIdAsync(id);
        }

        public async Task<Menu> CreateMenuAsync(Menu menu)
        {
            return await _menuRepository.CreateMenuAsync(menu);
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            await _menuRepository.UpdateMenuAsync(menu);
        }

        public async Task DeleteMenuAsync(Menu menu)
        {
            await _menuRepository.DeleteMenuAsync(menu);
        }
    }
}

