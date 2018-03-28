using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace fun2travel.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult PackageDetails(int id)
        {
            return View(id);
        }

        public IActionResult AdventureDetails(int id)
        {
            return View(id);
        }

        public IActionResult HotelDetail(int id)
        {
            return View(id);
        }
    }
}