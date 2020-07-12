using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;

namespace NowaiterApi.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IStatusRepository _statusRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository, ILocationRepository locationRepository, IStatusRepository statusRepository)
        {
            _restaurantRepository = restaurantRepository;
            _locationRepository = locationRepository;
            _statusRepository = statusRepository;
        }

        /**
         * Checking if there are any matching restaurants with the certain name 
         */
        public bool RestaurantExist(string name)
        {
            if (_restaurantRepository.GetRestaurantsListByName(name).Count == 0)
            {
                return false;
            }

            return true;
        }

        /**
         * Searches for the restaurant nearby and returns them back in order from closest to furthest by coordinates
         */
        public List<RestaurantProximityViewModel> RestaurantSearchByDistance(List<Restaurant> restaurantList, double lat, double lng)
        {
            // Initializing Geocoordinate object with current user coordinates 
            GeoCoordinate currentGeoCoordinate = new GeoCoordinate(lat, lng);

            // Initializing new View model list for proximity
            List<RestaurantProximityViewModel> restaurantProximityList = new List<RestaurantProximityViewModel>();

            //Initialize view model for proximity 
            foreach (var restaurant in restaurantList)
            {
                // Initializing a Geocoordinate object with the latitude and longitude of the restaurant after searching for location with restaurantId
                GeoCoordinate restaurantCoordinate = new GeoCoordinate(_locationRepository.GetLocationLatitude(restaurant.RestaurantId), _locationRepository.GetLocationLongitude(restaurant.RestaurantId));

                // Initializing the viewmodel for the restaurant proximity 
                restaurantProximityList.Add(new RestaurantProximityViewModel
                {
                    RestaurantId = restaurant.RestaurantId,
                    Name = restaurant.Name,
                    Address1 = restaurant.Address1,
                    Phone = restaurant.Phone,
                    DriveThru = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).DriveThru,
                    InStore = _statusRepository.GetRestaurantStatusById(restaurant.RestaurantId).InStore,
                    //DistanceTo = currentGeoCoordinate.GetDistanceTo(restaurantCoordinate)
                });
            }

            return restaurantProximityList;
        }
    }
}
