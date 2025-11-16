using Tripz.AppLogic.DTOs;
using Tripz.AppLogic.Queries;

namespace Tripz.AppLogic.Services
{
    public interface ITripService
    {
        Task<IEnumerable<TripDto>> GetTripsAsync(GetTripsQuery query);
    }
}