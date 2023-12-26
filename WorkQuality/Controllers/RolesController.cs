using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorkQuality.Models;
using WorkQuality.Models.RolesViewModels;

namespace WorkQuality.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;

        public RolesController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET:
        [HttpGet]
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        // GET: 
        [HttpGet]
        public IActionResult Users() => View(_userManager.Users.ToList());

        // GET: /Roles/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if(user!=null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                // Список ролей користувача.
                var userRoles = await _userManager.GetRolesAsync(user);
                // Усі ролі.
                var allRoles = _roleManager.Roles.ToList();
                // Список ролей, які були додані.
                var addedRoles = roles.Except(userRoles);
                // Список ролей, які були видалені.
                var removedRoles = userRoles.Except(roles);
                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                return RedirectToAction("Users");
            }
            return NotFound();
        }
    }
}
