using Microsoft.EntityFrameworkCore;
using Tripz.AppLogic.Queries;
using Tripz.AppLogic.Services;
using Tripz.Domain.Entities;
using Tripz.Infrastructure.Data;

namespace Tripz.Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly TripzDbContext _context;

        public TripRepository(TripzDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync(GetTripsQuery query)
        {
            var tripsQuery = _context.Trips.AsQueryable();

            if (!string.IsNullOrEmpty(query.EmployeeId))
            {
                tripsQuery = tripsQuery.Where(t => t.EmployeeId == query.EmployeeId);
            }

            if (query.TransportType.HasValue)
            {
                tripsQuery = tripsQuery.Where(t => (int)t.TransportType == query.TransportType.Value);
            }

            if (query.Month.HasValue && query.Year.HasValue)
            {
                tripsQuery = tripsQuery.Where(t =>
                    t.DepartureDate.Month == query.Month.Value &&
                    t.DepartureDate.Year == query.Year.Value);
            }

            return await tripsQuery
                .OrderByDescending(t => t.SubmittedAt)
                .ToListAsync();
        }
    }
}