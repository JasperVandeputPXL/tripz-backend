using System.ComponentModel.DataAnnotations;

namespace Tripz.Api.Models
{
    public class CreateTripRequest
    {
        [Required(ErrorMessage = "Employee ID is required")]
        [StringLength(50, ErrorMessage = "Employee ID cannot exceed 50 characters")]
        public string EmployeeId { get; set; } = string.Empty;

        [Required(ErrorMessage = "Employee name is required")]
        [StringLength(100, ErrorMessage = "Employee name cannot exceed 100 characters")]
        public string EmployeeName { get; set; } = string.Empty;

        [EnumDataType(typeof(TransportType), ErrorMessage = "Transport type must be a valid value")]
        public int TransportType { get; set; }

        [Required(ErrorMessage = "Departure date is required")]
        public DateTime DepartureDate { get; set; }

        [Required(ErrorMessage = "Return date is required")]
        public DateTime ReturnDate { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        [StringLength(100, ErrorMessage = "Destination cannot exceed 100 characters")]
        public string Destination { get; set; } = string.Empty;

        [Range(0d, double.MaxValue, ErrorMessage = "Distance must be greater than or equal to 0")]
        public decimal Distance { get; set; }

        [Required(ErrorMessage = "Purpose is required")]
        [StringLength(500, ErrorMessage = "Purpose cannot exceed 500 characters")]
        public string Purpose { get; set; } = string.Empty;

        [Range(0d, double.MaxValue, ErrorMessage = "Estimated cost must be greater than or equal to 0")]
        public decimal EstimatedCost { get; set; }
    }
}
