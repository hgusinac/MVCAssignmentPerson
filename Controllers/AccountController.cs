using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCAssignmentPerson.Database;
using MVCAssignmentPerson.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCAssignmentPerson.Controllers
{


    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) // Constructor Injection
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegViewModel userReg)

        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {

                    UserName = userReg.UserName,
                    Email = userReg.Email,
                    PhoneNumber = userReg.Phone,
                    FirstName = userReg.FirstName,
                    LastName = userReg.LastName,
                    BirthDate = userReg.BirthDate
                  
                };

                IdentityResult result = await _userManager.CreateAsync(user, userReg.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)

                {
                    ModelState.AddModelError(item.Code, item.Description);
                }
            }

            return View(userReg);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVeiwModel loginUser)
        {
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);
               
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Lock-out", "Too many login Attemts");
                }
            }


            return View(loginUser);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
