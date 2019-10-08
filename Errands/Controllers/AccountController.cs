using Errands.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Errands.Models.ViewModels;
using System.Security.Claims;
using MySqlX.XDevAPI.Common;


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

                ///setup logic for is eighteen or older claim
                if (result.Succeeded)
                {
                    Claim nameClaim = new Claim("FullName", $"{user.FirstName} { user.LastName} ");

                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    Claim dateOfBirthClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);
                    List<Claim> claims = new List<Claim> { nameClaim, emailClaim, dateOfBirthClaim };
                    await _userManager.AddClaimsAsync(user, claims);
                    //admin roles
                    /*  if (rvm.Email.ToLower() == "percivaltanner@gmail.com")
                      {

                          await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);

                      }
                         await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

              */

                //create objects for users


                }

            }
            return View();

        }
    }
}
