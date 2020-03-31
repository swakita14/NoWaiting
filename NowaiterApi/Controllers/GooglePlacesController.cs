using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NowaiterApi.Controllers
{
    public class GooglePlacesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}