﻿using System;
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

        void DeleteLocation(Location location);

        List<Location> GetNearLocationList(long lat, long lng);

        double GetLocationLatitude(int id);

        double GetLocationLongitude(int id);

    }
}
