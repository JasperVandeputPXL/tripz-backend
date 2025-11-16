using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripz.Domain;

namespace Tripz.AppLogic
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _repo;

        public TripService(ITripRepository repo)
        {
            _repo = repo;
        }

        public Trip RegisterTrip(Trip trip)
        {
            if (trip == null)
                throw new ArgumentNullException(nameof(trip));

            return _repo.Add(trip);
        }
    }
}