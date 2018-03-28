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
        private Repository repository;

        public DetailsController(Repository repository)
        {
            this.repository = repository;
        }
        public IActionResult PackageDetails()
        {
            return View(id);
        }

        public IActionResult AdventureDetails(int id)
        {
            return View(id);
        }

        public IActionResult HotelDetail(int id)
        {
            return View(repository.GetHotelById(id));
        }
    }
}