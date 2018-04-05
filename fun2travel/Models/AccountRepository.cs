using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fun2travel.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fun2travel.Models
{
    public class AccountRepository
    {
        const string roleNameAdmin = "Admin";
        const string roleNameUser = "User";

        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        RoleManager<IdentityRole> roleManager;
        IdentityDbContext identityContext;

        public AccountRepository(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
        IdentityDbContext identityContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.identityContext = identityContext;
        }

        public async Task<bool> TryLoginAsync(LoginVM viewModel)
        {
            // Create DB schema (first time)
            //var createSchemaResult = await identityContext.Database.EnsureCreatedAsync();

            // Create a hard coded user (first time)
            //var createResult = await userManager.CreateAsync(new IdentityUser("jerryteodor"),"P@ssw0rd");

            var loginResult = await signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false, false);
            return loginResult.Succeeded;
        }

        public async Task<bool> TryRegisterAsync(AccountRegisterNewUserVM model)
        {

            // Create a user
            var createResult = await userManager.CreateAsync(new IdentityUser(model.UserName), model.Password);
            if (createResult.Succeeded)
            {
                await CreateRoleAsync(model.UserName);
            }
            return createResult.Succeeded;

        }

        internal async Task CreateRoleAsync(string userName)
        {
            var user = await userManager.FindByNameAsync(userName);
            IdentityRole role = new IdentityRole();
            role.Name = roleNameUser;
            await roleManager.CreateAsync(role);
            await userManager.AddToRoleAsync(user, roleNameUser);
        }

        //internal async Task<object> FinduserbyidAsync(string v)
        //{
        //    IdentityUser user = await userManager.FindByIdAsync(v);
        //    await CreateRoleAsync(user);
        //    return true;
        //}

        internal async Task<string> CheckUserRoleByIdAsync(LoginVM viewModel)
        {
            IdentityUser model = await userManager.FindByNameAsync(viewModel.Username);
            var admin = await userManager.IsInRoleAsync(model, roleNameAdmin);
            var user = await userManager.IsInRoleAsync(model, roleNameUser);
            if (admin)
            {
                return "Admin";
            }
            else if (user)
            {
                return "User";
            }
            else
                return "No user found";
        }

        //public async Task<string> GetUserNameAsync(HttpContext httpContext)
        //{
        //    string userId = userManager.GetUserId(httpContext.User);
        //    IdentityUser user = await userManager.FindByIdAsync(userId);
        //    return user.UserName;
        //}

        //public async Task<bool> CreateUserAsync(AccountRegisterNewUserVM userInput)
        //{
        //    IdentityUser user = new IdentityUser(userInput.UserName);
        //    var result = await userManager.CreateAsync(user, userInput.Password);
        //    return result.Succeeded;
        //}

        //public async Task<bool> LoginUserAsync(LoginVM model)
        //{
        //    var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
        //    return result.Succeeded;
        //}

        //internal void logOut()
        //{
        //    signInManager.SignOutAsync();
        //}

        //public void CreateDB() //görs första gången för att skapa DB tabeller
        //{
        //    identityContext.Database.EnsureCreated();
        //}
    }
}
