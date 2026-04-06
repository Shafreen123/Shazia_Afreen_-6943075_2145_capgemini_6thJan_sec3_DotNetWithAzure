using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Core.DTOs
{
    public class BillDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = "";
        public string DoctorName { get; set; } = "";
        public decimal Amount { get; set; }
        public string Description { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime GeneratedAt { get; set; }
        public DateTime? PaidAt { get; set; }
    }

    public class CreateBillDto
    {
        [Required]
        public int AppointmentId { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        public string Description { get; set; } = "";
    }

    public class UpdateBillStatusDto
    {
        [Required]
        public string Status { get; set; } = "";
    }
}