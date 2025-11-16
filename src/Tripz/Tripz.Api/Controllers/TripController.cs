using Microsoft.AspNetCore.Mvc;
using Tripz.AppLogic;
using Tripz.Domain;

namespace Tripz.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TripController : ControllerBase
    {
        private readonly ITripService _tripService;

        public TripController(ITripService tripService)
        {
            _tripService = tripService;
        }

        [HttpPost("register")]
        public IActionResult RegisterTrip([FromBody] TripRequest request)
        {
            var trip = new Trip
            {
                Date = request.Date,
                Destination = request.Destination,
                DistanceKm = request.DistanceKm,
                Transport = request.Transport,
                Purpose = request.Purpose,
                Cost = request.Cost
            };

            var saved = _tripService.RegisterTrip(trip);
            return Ok(saved);
        }
    }

    public class TripRequest
    {
        public DateTime Date { get; set; }
        public string Destination { get; set; } = string.Empty;
        public double DistanceKm { get; set; }
        public TransportType Transport { get; set; }
        public string Purpose { get; set; } = string.Empty;
        public decimal? Cost { get; set; }
    }
}
