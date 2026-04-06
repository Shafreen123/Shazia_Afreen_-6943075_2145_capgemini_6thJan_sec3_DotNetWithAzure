using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Core.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; } = null!;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public string Description { get; set; } = "";

        // Pending, Paid, Cancelled
        public string Status { get; set; } = "Pending";

        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;

        public DateTime? PaidAt { get; set; }
    }
}