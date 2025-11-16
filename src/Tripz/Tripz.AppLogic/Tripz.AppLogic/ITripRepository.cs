using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tripz.Domain;

namespace Tripz.AppLogic
{
    public interface ITripRepository
    {
        Trip Add(Trip trip);
    }
}
