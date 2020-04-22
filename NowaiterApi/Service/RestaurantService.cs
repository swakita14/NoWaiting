using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;

namespace NowaiterApi.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
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
    }
}
