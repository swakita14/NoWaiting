using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces
{
    interface IRestaurantRepository
    {
        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant GetRestaurantById(int id);

        void Edit(Restaurant restaurant);

        void Delete(Restaurant restaurant);

        List<Restaurant> GetAllRestaurants();
    }
}
