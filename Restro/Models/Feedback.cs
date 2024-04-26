using System.ComponentModel.DataAnnotations;

namespace Restro.Models
{
    public class Feedback
    {
            [Key]
            public int FeedbackId { get; set; }

            [Required]
            public string CustomerName { get; set; }

            [Required]
            public string Email { get; set; }

            [Required]
            public string Message { get; set; }

            [Required]
            public DateTime Date { get; set; }

        }
    }
