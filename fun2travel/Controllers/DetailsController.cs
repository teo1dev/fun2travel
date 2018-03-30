using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
using fun2travel.Models.ViewModels;
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
            //AdventuresVM adventureDetailVM = new AdventuresVM
            //{
            //    Id = repository.GetAdventureById(id)

            //};
            return View(repository.GetAdventureByIdToVM(id));
        }

        private IActionResult View(Func<int, AdventuresVM> getAdventureById)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult HotelDetail(int id)
        {
            return View(repository.GetHotelByIdToVM(id));
        }
    }
}