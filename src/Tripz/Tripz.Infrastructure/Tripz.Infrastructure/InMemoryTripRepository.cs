using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripz.AppLogic;
using Tripz.Domain;

namespace Tripz.Infrastructure
{
    public class InMemoryTripRepository : ITripRepository
    {
        private readonly List<Trip> _trips = new();

        public Trip Add(Trip trip)
        {
            trip.Id = Guid.NewGuid();
            _trips.Add(trip);
            return trip;
        }
    }
}
