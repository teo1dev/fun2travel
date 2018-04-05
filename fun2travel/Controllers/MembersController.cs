using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fun2travel.Controllers
{
    public class MembersController : Controller
    {
        
        private readonly Repository repository;

        public MembersController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult IndexUserRegistred()
        {            
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        //[Route("Members")]
        public IActionResult Index()
        {
            AdminVM admin = new AdminVM { UserName = User.Identity.Name };
            admin.Bookings = repository.AllBookings();
            return View(admin);
        }

        [HttpGet]
        //[Route("Members")]
        [Authorize(Roles = "User")]
        public IActionResult IndexUser()
        {
            UserVM user = new UserVM { UserName = User.Identity.Name };            
            return View(user);
        }
        //// GET: /<controller>/
        //[Route("/Members/Login")]
        //[AllowAnonymous]
        //public IActionResult Login()
        //{
        //    return View();
        //}


        ////sätt [Authorize] på de sidor som bara skall nås när man är inloggad.

        ////för att se vilken användare som är inloggad:
        //[Authorize]
        //[Route("/members")]
        //public async Task<IActionResult> MembersAsync()
        //{
        //    string userName = await repository.GetUserNameAsync(HttpContext);
        //    var tmp = new LoggedInUserVM
        //    {
        //        UserName = userName
        //    };

        //    return View(tmp);
        //}
    }
}
