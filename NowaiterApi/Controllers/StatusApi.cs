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
        private readonly IStatusRepository _statusRepository;
        private readonly IAvailabilityService _availabilityService;
        
        public StatusApi( IStatusRepository statusRepository, IAvailabilityService availabilityService)
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
