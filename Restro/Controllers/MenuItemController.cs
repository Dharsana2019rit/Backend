using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Exceptions;
using Restro.Models;
using Restro.Services;

namespace Restro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IMenuItemService _menuItemService;

        public MenuItemsController(IMenuItemService menuItemService)
        {
            _menuItemService = menuItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItem>>> GetMenuItems()
        {
            var menuItems = await _menuItemService.GetAllMenuItemsAsync();
            return Ok(menuItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuItem>> GetMenuItem(int id)
        {
            try
            {
                var menuItem = await _menuItemService.GetMenuItemByIdAsync(id);
                if (menuItem == null)
                {
                    return NotFound($"Menu item with ID {id} not found.");
                }
                return Ok(menuItem);
            }
            catch (MenuItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<MenuItem>> CreateMenuItem(MenuItem menuItem)
        {
            try
            {
                var createdMenuItem = await _menuItemService.CreateMenuItemAsync(menuItem);
                return CreatedAtAction(nameof(GetMenuItem), new { id = createdMenuItem.MenuItemId }, createdMenuItem);
            }
            catch (MenuItemAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMenuItem(int id, MenuItem menuItem)
        {
            try
            {
                if (id != menuItem.MenuItemId)
                {
                    return BadRequest("Menu item ID mismatch.");
                }

                await _menuItemService.UpdateMenuItemAsync(menuItem);
                return NoContent();
            }
            catch (MenuItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {
            try
            {
                await _menuItemService.DeleteMenuItemAsync(id);
                return NoContent();
            }
            catch (MenuItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
