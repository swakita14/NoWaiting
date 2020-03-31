using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowaiterApi.Interfaces.Service;

namespace NowaiterApi.Controllers
{
    public class GooglePlacesController : Controller
    {
        private readonly IPlacesClient _placesService;

        public GooglePlacesController(IPlacesClient placesService)
        {
            _placesService = placesService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}