using fun2travel.Models;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fun2travel.Controllers
{
    public class AccountController : Controller
    {
        AccountRepository repository;
        public AccountController(AccountRepository repository)
        {
            this.repository = repository;

        }

        //// GET: /<controller>/
        //[AllowAnonymous]
        //[HttpGet]
        ////[Route("/Account/registernewuser/")]
        //public IActionResult RegisterNewUser()
        //{
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> RegisterNewUser(AccountRegisterNewUserVM model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    bool success = await repository.CreateUserAsync(model);
        //    if (!success)
        //    {
        //        ModelState.AddModelError(nameof(AccountRegisterNewUserVM.Password), "Password must be at least 6 chars");
        //        return View(model);
        //    }
        //    //return Content("Success!!"); //temp developer rad
        //    return RedirectToAction(nameof(LoginUser));
        //}

        //[AllowAnonymous]
        //[HttpGet]
        ////[Route("/login")]
        //public IActionResult LoginUser()
        //{
        //    return View();
        //}
        //[AllowAnonymous]
        //[HttpPost]
        //public async Task<IActionResult> LoginUser(LoginVM model)
        //{
        //    if (!ModelState.IsValid)
        //        return View(model);

        //    bool success = await repository.LoginUserAsync(model);
        //    if (success)
        //        return RedirectToAction(nameof(MembersController.MembersAsync), "Members");
        //    else return View(model);
        //}
        //[Authorize]
        //[HttpPost]
        //public IActionResult LogOut()
        //{
        //    repository.logOut();
        //    return RedirectToAction(nameof(AccountController.LoginUser), "Account");
        //}

        [HttpGet]
        //[Route("")]
        [Route("login")]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginVM { ReturnUrl = returnUrl };
            return View(model);
        }

        [HttpPost]
        [Route("logIn")]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            if (!await repository.TryLoginAsync(viewModel))
            {
                // Show login error
                ModelState.AddModelError(nameof(LoginVM.Username), "Invalid credentials");
                return View(viewModel);
            }

            // Redirect user
            if (string.IsNullOrWhiteSpace(viewModel.ReturnUrl))
                return RedirectToAction(nameof(MembersController.Index), "members");
            else
                return Redirect(viewModel.ReturnUrl);
        }

    }
}
