using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.DAL;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;


namespace NowaiterApi.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusApi : Controller
    {
        private readonly NowaiterContext _context;
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IStatusRepository _statusRepository;
        
        public StatusApi(NowaiterContext context, IRestaurantRepository restaurantRepository, IStatusRepository statusRepository)
        {
            _context = context;
            _restaurantRepository = restaurantRepository;
            _statusRepository = statusRepository;
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
        [Route("search/{name}")]
        [HttpGet]
        public IActionResult Search(string name)
        {
            // Getting restaurant with the matching search string 
            List<Restaurant> searchRestaurants = _restaurantRepository.GetRestaurantsByName(name);

            // If list is empty, there return error 
            if (searchRestaurants.Count == 0)
            {
                throw new ArgumentException($"Could not find any restaurants with the keyword {name}");
            }

            // Creating view model with relevant information for user
            List<RestaurantAvailabilityViewModel> currentAvailability = new List<RestaurantAvailabilityViewModel>();

            // Add each item into view model list 
            foreach (var restaurant in searchRestaurants)
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

    }
}
