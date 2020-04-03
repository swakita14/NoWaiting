using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Models.GooglePlaces;

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

            foreach (var placesid in _placesService.GetPlacesList())
            {
            }

        }
    }
}