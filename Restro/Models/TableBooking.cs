using Restro.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restro.Models
{
    public class TableBooking
    {
        [Key]
        public int TableBookingId { get; set; }

        [Required]
        public DateTime BookingDateTime { get; set; }

        [Required]
        public int NumberOfGuests { get; set; }

        public int TableNumber { get; set; } // Add new property for table number

        public bool IsBooked { get; set; }

        public int? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; } // Make Customer property nullable
    }
}