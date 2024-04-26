using Restro.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }

        [Required]
        public string Category { get; set; }

        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
