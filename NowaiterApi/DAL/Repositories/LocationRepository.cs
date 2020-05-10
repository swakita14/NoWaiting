using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly NowaiterContext _context;

        public LocationRepository(NowaiterContext context)
        {
            _context = context;
        }

        public Location AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();

            return location;
        }

        public void EditLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            Location existing = _context.Locations.Find(location.LocationId);

            if(existing ==null) throw new ArgumentException($"Could not find the location with location ID {location.LocationId}");

            _context.Locations.Remove(existing);
            _context.SaveChanges();
        }

        public Location GetLocationById(int id)
        {
            return _context.Locations.Find(id);
        }

        public Location GetLocationByRestaurantId(int restaurantId)
        {
            return _context.Locations.FirstOrDefault(x => x.RestaurantID == restaurantId);
        }

        public List<Location> GetAllLocations()
        {
            return _context.Locations.ToList();
        }

        public List<Location> GetNearLocationList(long lat, long lng)
        {
            return null;
        }

        
    }
}
