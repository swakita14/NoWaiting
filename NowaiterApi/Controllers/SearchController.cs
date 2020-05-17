using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models.ViewModel;


namespace NowaiterApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly ILocationRepository _locationRepository;

        public SearchController(IRestaurantService restaurantService, IRestaurantRepository restaurantRepository,
            IStatusRepository statusRepository, ILocationRepository locationRepository)
        {
            _restaurantRepository = restaurantRepository;
            _statusRepository = statusRepository;
            _restaurantService = restaurantService;
            _locationRepository = locationRepository;

        }

        /**
         * Method returns all the restaurants stored in the database
         */
        [Route("list")]
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_restaurantRepository.GetAllRestaurants());
        }

        /**
         * Get method to retrieve the restaurant information using the name 
         */
        [Route("{name}")]
        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            // If list is empty, there return error 
            if (!_restaurantService.RestaurantExist(name))
            {
                throw new ArgumentException($"Could not find any restaurants with the keyword {name}");
            }

            // Creating view model with relevant information for user
            List<RestaurantAvailabilityViewModel> currentAvailability = new List<RestaurantAvailabilityViewModel>();

            // Add each item into view model list 
            foreach (var restaurant in _restaurantRepository.GetRestaurantsListByName(name))
            {
                currentAvailability.Add(new RestaurantAvailabilityViewModel
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    Phone = restaurant.Phone,
                    Address1 = restaurant.Address1,
                    DriveThru = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).DriveThru,
                    InStore = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).InStore
                });
            }

            // Return the result
            return Ok(currentAvailability);
        }

        /**
         * GET method to return the restaurants nearest when give lat and long coordinates. 
         */
        [Route("{lat, lng")]
        [HttpGet]
        public IActionResult SearchByDistance(long lat, long lng)
        {
            // Initializing Geocoordinate object with current user coordinates 
            GeoCoordinate currentGeoCoordinate = new GeoCoordinate(lat, lng);

            // Initializing new View model list for proximity
            List<RestaurantProximityViewModel> restaurantProximityList = new List<RestaurantProximityViewModel>();

            //Initialize view model for proximity 
            foreach (var restaurant in _restaurantRepository.GetAllRestaurants())
            {
                // Initializing a Geocoordinate object with the latitude and longitude of the restaurant after searching for location with restaurantId
                GeoCoordinate restaurantCoordinate = new GeoCoordinate(_locationRepository.GetLocationByRestaurantId(restaurant.RestaurantId).Latitude, _locationRepository.GetLocationByRestaurantId(restaurant.RestaurantId).Longitude);

                // Initializing the viewmodel for the restaurant proximity 
                restaurantProximityList.Add(new RestaurantProximityViewModel
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    Address1 = restaurant.Address1,
                    Phone = restaurant.Phone,
                    DriveThru = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).DriveThru,
                    InStore = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).InStore,
                    DistanceTo = currentGeoCoordinate.GetDistanceTo(restaurantCoordinate)
                });
            }

            // Return a 200 with the sorted list with the closest location to furthest 
            return Ok(restaurantProximityList.OrderBy(x=> x.DistanceTo));
        }

    }
}