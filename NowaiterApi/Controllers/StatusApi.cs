using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.DAL;
using NowaiterApi.Interfaces;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using NowaiterApi.Models;
using NowaiterApi.Models.ViewModel;


namespace NowaiterApi.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusApi : Controller
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IRestaurantService _restaurantService;
        
        public StatusApi(IRestaurantRepository restaurantRepository, IStatusRepository statusRepository, IRestaurantService restaurantService)
        {
            _restaurantRepository = restaurantRepository;
            _statusRepository = statusRepository;
            _restaurantService = restaurantService;
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
         * POST method to add a single customer to drivethru count
         */
        [Route("drivethru/arrived/{restaurantId}")]
        [HttpPost]
        public IActionResult EnterDriveThru(int restaurantId)
        {
            return Ok();
        }

        /**
         * POST method to subtract single customer from drivethru count
         */
        [Route("drivethru/left/{restaurantId}")]
        [HttpPost]
        public IActionResult LeftDriveThru(int restaurantId)
        {
            return Ok();
        }

        /**
 * POST method to add a single customer to in-store count
 */
        [Route("instore/arrived/{restaurantId}")]
        [HttpPost]
        public IActionResult EnterInStore(int restaurantId)
        {
            return Ok();
        }

        /**
         * POST method to subtract single customer from in store count
         */
        [Route("instore/left/{restaurantId}")]
        [HttpPost]
        public IActionResult LeftInStore(int restaurantId)
        {
            return Ok();
        }

    }
}
