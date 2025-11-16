using Tripz.AppLogic.DTOs;
using Tripz.AppLogic.Queries;

namespace Tripz.AppLogic.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<IEnumerable<TripDto>> GetTripsAsync(GetTripsQuery query)
        {
            var trips = await _tripRepository.GetTripsAsync(query);

            return trips.Select(t => new TripDto
            {
                Id = t.Id,
                EmployeeId = t.EmployeeId,
                EmployeeName = t.EmployeeName,
                TransportType = t.TransportType.ToString(),
                DepartureDate = t.DepartureDate,
                ReturnDate = t.ReturnDate,
                Destination = t.Destination,
                EstimatedCost = t.EstimatedCost,
                Status = t.Status.ToString(),
                SubmittedAt = t.SubmittedAt
            });
        }
    }
}