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

namespace NowaiterApi.Controllers
{
    public class GooglePlacesController : Controller
    {
        private readonly IPlacesClient _placesService;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILocationRepository _locationRepository;

        public GooglePlacesController(IPlacesClient placesService, IRestaurantRepository restaurantRepository, ILocationRepository locationRepository)
        {
            _placesService = placesService;
            _restaurantRepository = restaurantRepository;
            _locationRepository = locationRepository;
        }

        public IActionResult Index()
        {
            StoreResults();

            return View();
        }

        public void StoreResults()
        {
            // Getting the place_id list and finding the details about each restaurant 
            foreach (var placesId in _placesService.GetPlacesList())
            {
                DetailResult result = _placesService.GetDetailResult(placesId);

                // Adding new restaurant
                _restaurantRepository.AddRestaurant(new Restaurant
                {
                    Name = result.Name,
                    Phone = result.FormattedPhoneNumber,
                    Address1 = result.FormattedAddress,
                    City = result.FormattedAddress.Split(',')[1],
                    State = result.FormattedAddress.Split(',')[2].Split(' ')[1],
                    ZipCode = result.FormattedAddress.Split(',')[2].Split(' ')[2],
                    DateUpdated = DateTime.Now,
                    GooglePlaceID = result.PlaceId
                });
            }

        }
    }
}