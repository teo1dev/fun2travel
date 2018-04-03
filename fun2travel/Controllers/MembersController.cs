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
        private readonly AccountRepository repository;

        public MembersController(AccountRepository repository)
        {
            this.repository = repository;

        }

        [HttpGet]
        [Route("Members")]
        public IActionResult Index()
        {
            return View(new LoggedInUserVM { UserName = User.Identity.Name });
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
