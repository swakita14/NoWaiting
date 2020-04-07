using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.DAL;
using NowaiterApi.Interfaces;


namespace NowaiterApi.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantStatusController : Controller
    {
        private readonly NowaiterContext _context;
        private readonly IRestaurantRepository _restaurantRepository;
        
        public RestaurantStatusController(NowaiterContext context, IRestaurantRepository restaurantRepository)
        {
            _context = context;
            _restaurantRepository = restaurantRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_restaurantRepository.GetAllRestaurants());
        }
    }
}
