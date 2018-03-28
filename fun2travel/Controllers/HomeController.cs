using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using fun2travel.Models;

namespace fun2travel.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository repository;

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Booking()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Registration()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Login()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult Adventures()
        {
            return View();
        }

        public IActionResult Packages()
        {
            return View();
        }

      
    }
}
