
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces.Repository;
using NowaiterApi.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;



namespace NowaiterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IAvailabilityService _availabilityService;
        
        public StatusController( IStatusRepository statusRepository, IAvailabilityService availabilityService)
        {
            _statusRepository = statusRepository;
            _availabilityService = availabilityService;
        }


        /**
         * POST method to add a single customer to drivethru count
         */
        [Route("drivethru/arrived/{restaurantId}")]
        [HttpPost]
        public IActionResult EnterDriveThru(int restaurantId)
        {
            return Ok(_availabilityService.AddDriveThru(_statusRepository.GetRestaurantStatusById(restaurantId)));
        }

        /**
         * POST method to subtract single customer from drivethru count
         */
        [Route("drivethru/left/{restaurantId}")]
        [HttpPost]
        public IActionResult LeftDriveThru(int restaurantId)
        {
            return Ok(_availabilityService.LeftDriveThru(_statusRepository.GetRestaurantStatusById(restaurantId)));
        }

        /**
 * POST method to add a single customer to in-store count
 */
        [Route("instore/arrived/{restaurantId}")]
        [HttpPost]
        public IActionResult EnterInStore(int restaurantId)
        {
            return Ok(_availabilityService.AddInStore(_statusRepository.GetRestaurantStatusById(restaurantId)));
        }

        /**
         * POST method to subtract single customer from in store count
         */
        [Route("instore/left/{restaurantId}")]
        [HttpPost]
        public IActionResult LeftInStore(int restaurantId)
        {
            return Ok(_availabilityService.LeftDriveThru(_statusRepository.GetRestaurantStatusById(restaurantId)));
        }

    }
}
