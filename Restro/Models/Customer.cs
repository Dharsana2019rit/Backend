using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class Customer
    {
            [Key]
            public int CustomerId { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            public string Phone { get; set; }

            public ICollection<TableBooking> TableBookings { get; set; }


        }
    }
