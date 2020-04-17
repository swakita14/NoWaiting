using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.DAL;
using NowaiterApi.Interfaces;
using NowaiterApi.Models;


namespace NowaiterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StatusController : Controller
    {
        private readonly NowaiterContext _context;
        private readonly IRestaurantRepository _restaurantRepository;
        
        public StatusController(NowaiterContext context, IRestaurantRepository restaurantRepository)
        {
            _context = context;
            _restaurantRepository = restaurantRepository;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Search(string name)
        {
            List<Restaurant> searchRestaurants = _restaurantRepository.GetRestaurantsByName(name);

            if (searchRestaurants.Count == 0)
            {
                throw new ArgumentException($"Could not find any restaurants with the keyword {name}");
            }

            return Ok(_restaurantRepository.GetRestaurantsByName(name));
        }

        /**
         * Retrieves the status of the restaurant. 
         */
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Availability(int restaurantId)
        {
            return Ok();
        }
    }
}
