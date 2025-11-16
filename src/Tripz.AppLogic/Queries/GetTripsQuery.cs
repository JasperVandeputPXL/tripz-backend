namespace Tripz.AppLogic.Queries
{
    public class GetTripsQuery
    {
        public string? EmployeeId { get; set; }
        public int? TransportType { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}