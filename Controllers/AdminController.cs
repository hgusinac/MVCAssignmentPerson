using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCAssignmentPerson.Database;
using Microsoft.AspNetCore.Authorization;
using MVCAssignmentPerson.Models.ViewModel;

namespace MVCAssignmentPerson.Controllers
{
    [Authorize(Roles ="Admin")]//Är du inloggad så har du tillgång till detta ! 
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _AppUser;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _AppUser = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult UserList()
        {
            return View(_AppUser.Users.ToList());
        }


        public async Task<IActionResult> Details(string id)
        {
            AppUser userFound = await _AppUser.FindByIdAsync(id);

            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }

            return View(userFound);
        }

        public async Task<IActionResult> RolesManagment(string id)
        {
            AppUser userFound = await _AppUser.FindByIdAsync(id);



            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }

            IList<string> userRoles = await _AppUser.GetRolesAsync(userFound);

            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagmentViewModel viewModel = new RolesManagmentViewModel(id, userRoles, identityRoles);

            return View(viewModel);
        }

        public async Task<IActionResult> AddRoleToUser(string userId, string roleName)//lägg till en Roll
        {

            AppUser userFound = await _AppUser.FindByIdAsync(userId);


            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }

            var result = await _AppUser.AddToRoleAsync(userFound, roleName);




            if (result.Succeeded)
            {
                return RedirectToAction("RolesManagment", new { id = userId });
            }

            IList<string> userRoles = await _AppUser.GetRolesAsync(userFound);

            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagmentViewModel viewModel = new RolesManagmentViewModel(userId, userRoles, identityRoles);

            ViewBag.ErroMsg = "Failed to change role for user!";

            return View("RolesManagment", viewModel);

        }
        public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)//Ta bort till Roll
        {

            AppUser userFound = await _AppUser.FindByIdAsync(userId);


            if (userFound == null)
            {
                return RedirectToAction(nameof(UserList));
            }

            var result = await _AppUser.RemoveFromRoleAsync(userFound, roleName);




            if (result.Succeeded)
            {
                return RedirectToAction("RolesManagment", new { id = userId });
            }

            IList<string> userRoles = await _AppUser.GetRolesAsync(userFound);

            List<IdentityRole> identityRoles = _roleManager.Roles.ToList();

            RolesManagmentViewModel viewModel = new RolesManagmentViewModel(userId, userRoles, identityRoles);

            ViewBag.ErroMsg = "Failed to change role for user!";

            return View("RolesManagment", viewModel);

        }


        public IActionResult RoleList()
        {
            return View(_roleManager.Roles.ToList());
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string roleName)
        {

            if (string.IsNullOrWhiteSpace(roleName))
            {
                ViewBag.ErrorMsg = "Not able to create Role. Minimi 3 long and not blankspace";
                return View("CreateRole", roleName);
            }
            IdentityRole role = new IdentityRole(roleName);

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(RoleList));
            }

            ViewBag.ErrorMsg = "Roel was not Created.";
            return View("CreateRole", roleName);

        }
        public async Task<IActionResult> RemoveRole(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName)&&
                await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = await _roleManager.FindByNameAsync(roleName);
                var result = await _roleManager.DeleteAsync(role);
            }




            return RedirectToAction(nameof(RoleList));





        }
    }
}
