using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.GoogleClient;
using NowaiterApi.Models;
using NowaiterApi.Models.GooglePlaces;
using NowaiterApi.Models.GooglePlaces.QuickType;
using Location = NowaiterApi.Models.Location;

namespace NowaiterApi.Controllers
{
    public class GooglePlacesController : Controller
    {
        private readonly IPlacesClient _placesService;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IStatusRepository _statusRepository;

        public GooglePlacesController(IPlacesClient placesService, IRestaurantRepository restaurantRepository, ILocationRepository locationRepository, IStatusRepository statusRepository)
        {
            _placesService = placesService;
            _restaurantRepository = restaurantRepository;
            _locationRepository = locationRepository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            //IntializeGoogleLocations();

            return View();
        }

        public void InitializeGoogleLocations()
        {
            // Getting the place_id list and finding the details about each restaurant 
            foreach (var placesId in _placesService.GetPlacesList())
            {
                // Getting the details of the information with the place_id
                DetailResult result = _placesService.GetDetailResult(placesId);

                // Creating new restaurant object with the information from Places API
                Restaurant newRestaurant = new Restaurant
                {
                    Name = result.Name,
                    Phone = result.FormattedPhoneNumber,
                    Address1 = result.FormattedAddress,
                    City = result.FormattedAddress.Split(',')[1],
                    State = result.FormattedAddress.Split(',')[2].Split(' ')[1],
                    ZipCode = result.FormattedAddress.Split(',')[2].Split(' ')[2],
                    DateUpdated = DateTime.Now,
                    GooglePlaceID = result.PlaceId
                };

                // Adding new restaurant
                _restaurantRepository.AddRestaurant(newRestaurant);

                // Creating a location object with the result
                Location newLocation = new Location
                {
                    Latitude = result.Geometry.Location.Lat,
                    Longitude = result.Geometry.Location.Lng,
                    RestaurantID = newRestaurant.RestaurantId
                };

                // Adding new location for the restaurant 
                _locationRepository.AddLocation(newLocation);

                // Initializing status of the restaurant
                Status newStatus = new Status
                {
                    RestaurantID = newRestaurant.RestaurantId,
                    Drive_Thru = 0,
                    In_Store = 0
                };

                // Adding the Status to Db
                _statusRepository.AddStatus(newStatus);

            }

        }
    }
}