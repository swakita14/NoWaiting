using System.Collections.Generic;
using NowaiterApi.Models;

namespace NowaiterApi.Interfaces.Service
{
    public interface IRestaurantService
    {
         bool RestaurantExist(string name);
    }
}