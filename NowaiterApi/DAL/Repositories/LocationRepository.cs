using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly NowaiterContext _nowaiterContext;

        public LocationRepository(NowaiterContext nowaiterContext)
        {
            _nowaiterContext = nowaiterContext;
        }

        public Location AddLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public List<Location> GetAllLocations()
        {
            throw new NotImplementedException();
        }
    }
}
