using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Group3.Models;


namespace Group3.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdminController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            return View(new AdminViewModel(roleManager, userManager));
        }

        public IActionResult QueryUserRoles(string id)
        {
            // userManager.FindByIdAsync(id); would require LazyLoading for user.UserRoles to be loaded
            var user = userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x => x.Id == id).FirstOrDefault();
            if (user != null) {
                return Json(user.UserRoles.Select(x => x.Role.Name).ToList());
            }

            return BadRequest($"User with id={id} could not be found.");
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(string id, string[] selectedRoles)
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");

            var user = userManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).Where(x => x.Id == id).FirstOrDefault();
            if (user != null) {
                var userRoles = user.UserRoles.Select(x => x.Role.Name).ToList();

                foreach (string role in selectedRoles.Where(r1 => !userRoles.Any(r2 => r2.Equals(r1))))
                    await userManager.AddToRoleAsync(user, role);

                foreach (string role in userRoles.Where(r1 => !selectedRoles.Any(r2 => r2.Equals(r1))))
                    await userManager.RemoveFromRoleAsync(user, role);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUser(string id)
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");

            var user = await userManager.FindByIdAsync(id);
            if (user == null) 
                return BadRequest($"User with id={id} does not exist.");

            // TODO: check if user is the last admin

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return PartialView("_UsersView", new AdminViewModel(roleManager, userManager).Users);

            return BadRequest($"User with id={id} could not be deleted.");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
                return BadRequest($"Role with id={id} does not exist.");

            if (role.Name == "Admin")
                return BadRequest($"Admin role is protected.");

            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded)
                return PartialView("_RolesView", new AdminViewModel(roleManager, userManager).Roles);

            return BadRequest($"Role with id={id} could not be deleted.");            
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (ModelState.IsValid) {
                var result = await roleManager.CreateAsync(new ApplicationRole(roleName));
                if (result.Succeeded) {
                    return PartialView("_RolesView", new AdminViewModel(roleManager, userManager).Roles);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(string roleId, string roleName)
        {
            if (ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(roleId);
                if (role == null)
                    return BadRequest($"Role with id={roleId} could not be found.");

                if (role.Name == "Admin")
                    return BadRequest($"Admin role is protected.");

                role.Name = roleName;

                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded) {
                    return PartialView("_RolesView", new AdminViewModel(roleManager, userManager).Roles);
                }

                return BadRequest($"Role with id='{roleId}' could not be updated with name='{roleName}'.");
            }

            return BadRequest(ModelState);

        }
        [HttpPost]
        public IActionResult SearchUsers(string search)
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            var users = new AdminViewModel(roleManager, userManager).Users;

            return (string.IsNullOrEmpty(search)) 
                ? PartialView("_UsersView", users)
                : PartialView("_UsersView", users.Where(
                      r => r.UserName.Contains(search, StringComparison.OrdinalIgnoreCase) 
                       || r.FirstName.Contains(search, StringComparison.OrdinalIgnoreCase)
                        || r.LastName.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        [HttpPost]
        public IActionResult SearchRoles(string search)
        {
            ViewBag.Roles = new SelectList(roleManager.Roles, "Name", "Name");
            var roles = new AdminViewModel(roleManager, userManager).Roles;

            return (string.IsNullOrEmpty(search))
                ? PartialView("_RolesView", roles)
                : PartialView("_RolesView", roles.Where(r => r.Name.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }
    }
}