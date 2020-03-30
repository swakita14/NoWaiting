using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    interface ILocationRepository
    {
        List<Location> GetAllLocations();

        Location AddLocation(Location location);
    }
}
