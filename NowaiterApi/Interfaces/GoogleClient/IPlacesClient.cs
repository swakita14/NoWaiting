using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models.GooglePlaces;

namespace NowaiterApi.Interfaces.Service
{
    public interface IPlacesClient
    {
        List<PlacesResult> GetPlacesList();

        PlacesResult GetPlacesResult(string type, Location location);
    }
}
