﻿using System;
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

        //private readonly AccountRepository createDB;

        //public HomeController(AccountRepository createDB)
        //{
        //    this.createDB = createDB;
        //}

        public HomeController(Repository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
           
            return View(repository.AllHotelandActivitytoVM());
        }

        public IActionResult SelectHotelandActivity(string locationName, string activityName)
        {
            //var partialView = new ResultVM();
            //partialView = repository.FilterHotelandActivityPartialView(locationName, activityName);
            //return View(repository.FilterHotelandActivityPartialView(locationName, activityName));
            return PartialView("_ResultBox", repository.FilterHotelandActivityPartialView(locationName, activityName));
        }

     //public IActionResult AdminLoggedIn()
     //   {
     //       return View(repository.AllBookings);
     //   }

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

        public IActionResult Mail()
        {
            return View();
        }
    }
}
