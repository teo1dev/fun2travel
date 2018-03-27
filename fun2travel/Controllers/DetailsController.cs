using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fun2travel.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult PackageDetails()
        {
            return View();
        }

        public IActionResult AdventureDetails()
        {
            return View();
        }

        public IActionResult HotelDetail()
        {
            return View();
        }
    }
}