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
        private readonly Repository repository;

        public DetailsController(Repository repository)
        {
            this.repository = repository;
        }

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
            //var hotel = repository.GetHotelByIdToVM(id);
            return View(repository.GetHotelByIdToVM(id));
        }
    }
}