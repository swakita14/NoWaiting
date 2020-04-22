using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;

namespace NowaiterApi.DAL.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly NowaiterContext _context;

        public RestaurantRepository(NowaiterContext context)
        {
            _context = context;
        }
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public void Delete(Restaurant restaurant)
        {
            Restaurant existing = _context.Restaurants.Find(restaurant.RestaurantId);

            if(existing == null) throw new ArgumentException($"Count not find the restaurant with ID {restaurant.RestaurantId}");

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();

        }

        public void Edit(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _context.Restaurants.Find(id);
        }

        public Restaurant GetRestaurantWithPlaceId(string placeId)
        {
            return _context.Restaurants.FirstOrDefault(x => x.GooglePlaceId.Equals(placeId));
        }

        public List<Restaurant> GetRestaurantsListByName(string name)
        {
            return _context.Restaurants.Where(x => x.Name.Contains(name)).ToList();
        }

    }
}
