using System.Collections.Generic;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;

namespace NowaiterApi.Interfaces.Service
{
    public interface IRestaurantService
    {
         bool RestaurantExist(string name);

         List<RestaurantProximityViewModel> RestaurantSearchByDistance(List<Restaurant> restaurantList, double lat, double lng);
    }
}