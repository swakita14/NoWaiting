using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Models.GooglePlaces;
using NowaiterApi.Models.GooglePlaces.QuickType;

namespace NowaiterApi.Controllers
{
    public class GooglePlacesController : Controller
    {
        private readonly IPlacesClient _placesService;
        private readonly IRestaurantRepository _restaurantRepository;

        public GooglePlacesController(IPlacesClient placesService, IRestaurantRepository restaurantRepository)
        {
            _placesService = placesService;
            _restaurantRepository = restaurantRepository; 
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

                _restaurantRepository.AddRestaurant(new Restaurant
                {
                    Name = result.Name,
                    Phone = result.FormattedPhoneNumber,
                    Address1 = result.FormattedAddress,
                    DateUpdated = DateTime.Now,
                    GooglePlaceID = result.PlaceId
                });
            }

        }
    }
}