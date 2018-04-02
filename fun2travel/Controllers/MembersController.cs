using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models;
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
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        //Här ska routen och action till inloggningsida för admin och andra users vara

        //sätt [Authorize] på de sidor som bara skall nås när man är inloggad.
    }
}
