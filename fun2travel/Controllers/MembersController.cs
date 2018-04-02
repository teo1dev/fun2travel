using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fun2travel.Controllers
{
    public class MembersController : Controller
    {
        // GET: /<controller>/
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
    }
}
