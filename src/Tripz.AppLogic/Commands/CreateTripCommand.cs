using Tripz.Domain.Enums;

namespace Tripz.AppLogic.Commands
{
    public class CreateTripCommand
    {
        public string EmployeeId { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public TransportType TransportType { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Destination { get; set; } = string.Empty;
        public decimal Distance { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public decimal EstimatedCost { get; set; }
    }
}
