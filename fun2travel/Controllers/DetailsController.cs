using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
using Microsoft.AspNetCore.Mvc;

namespace fun2travel.Controllers
{
    public class DetailsController : Controller
    {
        private Repository repository = new Repository();

        
        public IActionResult PackageDetails(int id)
        {
            return View(id);
        }

        public IActionResult AdventureDetails(int id)
        {
            return View(id);
        }

        [HttpGet]
        public IActionResult HotelDetail(int id)
        {
            return View(repository.GetHotelById(id));
        }
    }
}