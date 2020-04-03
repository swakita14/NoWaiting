using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models.GooglePlaces;
using NowaiterApi.Models.GooglePlaces.QuickType;
using Location = NowaiterApi.Models.GooglePlaces.Location;

namespace NowaiterApi.Interfaces.Service
{
    public interface IPlacesClient
    {
        List<string> GetPlacesList();

        PlacesResponse GetPlacesResult(string type, Location location, string radius);

        DetailResult GetDetailResult(string placeId);
    }
}
