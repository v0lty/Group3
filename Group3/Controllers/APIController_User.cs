using Group3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // USER RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetCurrentUser")]
        public JsonResult GetCurrentUser()
        {
            var user = dbContext.Users
                .Where(x => x.UserName == User.Identity.Name)
                .Include(x => x.Pictures)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("GetUserById")]
        public JsonResult GetUserById(string userId)
        {
            var user = dbContext.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Posts)
                .Include(x => x.Chats)
                .Include(x => x.Pictures)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            return new JsonResult(user);
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public JsonResult GetAllUsers()
        {
            var users = dbContext.Users
                .Include(x => x.Pictures)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role);

            return new JsonResult(users);
        }

        [HttpPost]
        [Route("GetUserByName")]
        public JsonResult GetUserByName(string search)
        {
            var users = dbContext.Users
                .Include(x => x.Pictures)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToList();

            if (!string.IsNullOrEmpty(search))
            {
                var filters = search.Split(',').ToList();

                users = users.Where(s => filters.Any(t => !string.IsNullOrWhiteSpace(t.Trim()) && (
                           s.Name.Contains(t.Trim(), StringComparison.OrdinalIgnoreCase)
                       || s.Email.Contains(t.Trim(), StringComparison.OrdinalIgnoreCase)))).ToList();
            }

            return new JsonResult(users);
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<JsonResult> SignIn(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                var user = dbContext.Users
                    .Where(x => x.UserName == email)
                    .Include(x => x.Pictures)
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .FirstOrDefault();

                return new JsonResult(user);
            }
            else if (result.IsLockedOut) {
                var user = dbContext.Users.Where(x => x.UserName == email).FirstOrDefault();
                Response.StatusCode = (int)System.Net.HttpStatusCode.Locked;
                return new JsonResult(new { Success = "False", responseText = string.Format($"You are banned until {user.LockoutEnd.ToString()}") });
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to sign in user '{email}.'") });
            }
        }

        [HttpGet]
        [Route("SignOut")]
        public async Task<JsonResult> SignOut()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }

            return new JsonResult(null);
        }

        [HttpPost]
        [Route("EditUser")]
        public JsonResult EditUser(string email, string firstName, string lastName, DateTime birthdate)
        {
            var user = dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (user == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Could not find user '{email}.'") });
            }

            user.Email = email;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Birthdate = birthdate;

            dbContext.Users.Update(user);
            dbContext.SaveChanges();

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<JsonResult> CreateUser(string email, string firstName, string lastName, DateTime birthdate, string location, string password)
        {
            var existingUser = dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (existingUser != null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"User already exist '{email}.'") });
            }

            var user = new ApplicationUser()
            {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Location = location,
                Email = email,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                PhoneNumber = String.Empty,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, password),
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            await this.userManager.AddToRoleAsync(user, "User");
            dbContext.SaveChanges();

            return new JsonResult(user);
        }

        [HttpPost]
        [Route("RemoveUser")]
        public JsonResult RemoveUser(string userId)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"User with id '{userId}' not found.") });
            }

            if (user.UserName == User.Identity.Name) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"You can't remove yourself.") });
            }
            
            try {
                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }
            catch (Exception ex) {
                // TODO: check ApplicationDbContext.cs line 75.
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = ex.Message 
                    + ex.InnerException != null ? $"\n\nInner Exception: {ex.InnerException.Message}" : "" });
            }

            return new JsonResult(null);
        }

        [HttpPost]
        [Route("BanUser")]
        public JsonResult BanUser(string userId, string invokeBan, string endDate)
        {
            var user = dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
            if (user == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"User with id '{userId}' not found.") });
            }

            if (endDate == null) {
                user.LockoutEnabled = false;
                user.LockoutEnd = null;
            }
            else
            {
                var date = new DateTimeOffset(DateTime.Parse(endDate));
                if (date < DateTime.Now) {
                    user.LockoutEnabled = false;
                    user.LockoutEnd = null;
                }
                else {
                    user.LockoutEnabled = bool.Parse(invokeBan);
                    user.LockoutEnd = date;
                }
            }

            dbContext.Users.Update(user);
            dbContext.SaveChanges();

            return new JsonResult(endDate);
        }

        [HttpGet]
        [Route("GetAllRoles")]
        public JsonResult GetAllRoles()
        {
            return new JsonResult(dbContext.Roles.Include(x => x.UserRoles).ThenInclude(x => x.User));
        }

        [HttpPost]
        [Route("SetUserRoles")]
        public async Task<JsonResult> SetUserRoles(string userId, string roleArrayString)
        {
            var user = dbContext.Users
                .Where(x => x.Id == userId)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefault();

            if (user == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"User with id '{userId}' not found.") });
            }

            var userRoles = user.UserRoles.Select(x => x.Role.Name).ToList();
            var roleArray = roleArrayString.Split(',');
            if (roleArray == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"No roles selected.") });
            }

            foreach (string role in roleArray.Where(r1 => !userRoles.Any(r2 => r2.Equals(r1))))
                await userManager.AddToRoleAsync(user, role);

            foreach (string role in userRoles.Where(r1 => !roleArray.Any(r2 => r2.Equals(r1))))
                await userManager.RemoveFromRoleAsync(user, role);

            dbContext.SaveChanges();

            return new JsonResult(null);
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<JsonResult> CreateRole(string roleName)
        {
            var result = await roleManager.CreateAsync(new ApplicationRole(roleName));

            if (result.Succeeded == false) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to create role.") });
            }     

            return new JsonResult(roleName);
        }

        [HttpPost]
        [Route("EditRole")]
        public async Task<JsonResult> EditRole(string roleId, string roleName)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null) { 
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Role with id={roleId} could not be found.") });
            }

            if (role.Name == "Admin") {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Admin role is protected.") });
            }

            role.Name = roleName;

            var result = await roleManager.UpdateAsync(role);
            if (result.Succeeded == false) { 
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to edit role.") });
            }

            return new JsonResult(roleName);
        }

        [HttpPost]
        [Route("DeleteRole")]
        public async Task<JsonResult> DeleteRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Role with id={roleId} does not exist.") });
            }

            if (role.Name == "Admin") {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Admin role is protected.") });
            }
  
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded == false) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to delete role.") });
            }

            return new JsonResult(roleId);
        }
    }
}