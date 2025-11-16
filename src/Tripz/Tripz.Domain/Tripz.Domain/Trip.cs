using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripz.Domain
{
    public class Trip
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Destination { get; set; }
        public double DistanceKm { get; set; }
        public TransportType Transport { get; set; }
        public string Purpose { get; set; }
        public decimal? Cost { get; set; }

        public decimal CalculateReimbursement()
        {
            if (Transport == TransportType.Bike)
            {
                return (decimal)DistanceKm * 0.25m;
            }
            else if (Transport == TransportType.Car)
            {
                return (decimal)DistanceKm * 0.40m;
            }
            else if (Transport == TransportType.PublicTransport)
            {
                if (Cost != null)
                    return (decimal)Cost;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }
    }

}
