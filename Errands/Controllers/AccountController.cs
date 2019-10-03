using Errands.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errands.Models.ViewModels;

namespace Errands.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
         public IActionResult Register()
        {
           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Email = rvm.Email,
                    UserName = rvm.Email,
                    NormalizedEmail = rvm.Email.ToLower(),
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    Birthday = rvm.Birthday,

                };
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "I'm sorry something went wrong. Please try again.");

                }
            }

            ///setup logic for is eighteen or older claim
        }

        
    }
}
