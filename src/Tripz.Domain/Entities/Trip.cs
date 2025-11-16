using Tripz.Domain.Enums;

namespace Tripz.Domain.Entities
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public TransportType TransportType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Destination { get; set; } = string.Empty;
        public decimal EstimatedCost { get; set; }
        public TripStatus Status { get; set; }
        public DateTime SubmittedAt { get; set; }
    }
}