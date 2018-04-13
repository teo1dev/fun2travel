using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fun2travel.Models;
using fun2travel.Models.ViewModels;

namespace fun2travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;
        private readonly AccountRepository accrep;

        public HomeController(Repository repository, AccountRepository accrep)
        {
            this.repository = repository;
            this.accrep = accrep;
        }
        public IActionResult Index()
        {
            //accrep.CreateDB();
            return View(repository.AllHotelandActivitytoVM());
        }

        public IActionResult SelectHotelandActivity(string locationName, string activityName)
        {
            return PartialView("_ResultBox", repository.FilterHotelandActivityPartialView(locationName, activityName));
        }

        public IActionResult Error()
        {
            return base.View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Hotels()
        {
            return View(repository.GetAllHotelNames());
        }

        [HttpGet]
        public IActionResult Adventures()
        {
            return View(repository.GetAllAdventures());
        }

        public IActionResult Packages()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Mail()
        {
            return View();
        }
    }
}
