using Tripz.AppLogic.Commands;
using Tripz.AppLogic.DTOs;
using Tripz.AppLogic.Queries;
using Tripz.Domain.Entities;
using Tripz.Domain.Enums;

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

        public async Task<TripDto?> GetTripByIdAsync(Guid id)
        {
            var trip = await _tripRepository.GetTripByIdAsync(id);
            
            if (trip == null)
                return null;

            return new TripDto
            {
                Id = trip.Id,
                EmployeeId = trip.EmployeeId,
                EmployeeName = trip.EmployeeName,
                TransportType = trip.TransportType.ToString(),
                DepartureDate = trip.DepartureDate,
                ReturnDate = trip.ReturnDate,
                Destination = trip.Destination,
                EstimatedCost = trip.EstimatedCost,
                Status = trip.Status.ToString(),
                SubmittedAt = trip.SubmittedAt
            };
        }

        public async Task<TripDto> CreateTripAsync(CreateTripCommand command)
        {
            var trip = new Trip
            {
                Id = Guid.NewGuid(),
                EmployeeId = command.EmployeeId,
                EmployeeName = command.EmployeeName,
                TransportType = command.TransportType,
                DepartureDate = command.DepartureDate,
                ReturnDate = command.ReturnDate,
                Destination = command.Destination,
                Distance = command.Distance,
                Purpose = command.Purpose,
                EstimatedCost = command.EstimatedCost,
                Status = TripStatus.Submitted,
                SubmittedAt = DateTime.UtcNow
            };

            var createdTrip = await _tripRepository.CreateTripAsync(trip);

            return new TripDto
            {
                Id = createdTrip.Id,
                EmployeeId = createdTrip.EmployeeId,
                EmployeeName = createdTrip.EmployeeName,
                TransportType = createdTrip.TransportType.ToString(),
                DepartureDate = createdTrip.DepartureDate,
                ReturnDate = createdTrip.ReturnDate,
                Destination = createdTrip.Destination,
                EstimatedCost = createdTrip.EstimatedCost,
                Status = createdTrip.Status.ToString(),
                SubmittedAt = createdTrip.SubmittedAt
            };
        }
    }
}