using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    public interface ILocationRepository
    {
        List<Location> GetAllLocations();

        Location AddLocation(Location location);
        Location GetLocationById(int id);

        void EditLocation(Location location);

        Location GetLocationByRestaurantId(int restaurantId);

        void DeleteLocation(Location location);


    }
}
