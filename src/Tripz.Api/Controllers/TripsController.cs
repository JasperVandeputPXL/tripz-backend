using Microsoft.AspNetCore.Mvc;
using Tripz.Api.Models;
using Tripz.AppLogic.Queries;
using Tripz.AppLogic.Services;

namespace Tripz.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TripsController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripsController(ITripService tripService)
        {
            _tripService = tripService;
        }

        /// <summary>
        /// Get all submitted trips with optional filtering and pagination.
        /// Allows managers to filter by employee, transport type, or date (month/year).
        /// </summary>
        /// <param name="request">Filter and pagination parameters</param>
        /// <returns>Paginated list of trips with metadata</returns>
        /// <response code="200">Returns the paginated list of trips</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        // [Authorize(Roles = "Manager")] // TODO: Uncomment when authentication is implemented
        public async Task<IActionResult> GetTrips([FromQuery] GetTripsRequest request)
        {
            // With [ApiController], invalid model state returns 400 automatically.
            var query = new GetTripsQuery
            {
                EmployeeId = request.EmployeeId,
                TransportType = request.TransportType,
                Month = request.Month,
                Year = request.Year
            };

            var trips = (await _tripService.GetTripsAsync(query)).ToList();
            var totalCount = trips.Count();

            var paginatedTrips = trips
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            var result = new
            {
                data = paginatedTrips,
                pagination = new
                {
                    page = request.Page,
                    pageSize = request.PageSize,
                    totalCount,
                    totalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
                }
            };

            return Ok(result);
        }
    }
}