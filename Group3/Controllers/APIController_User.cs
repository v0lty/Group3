﻿using Group3.Models;
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
        [Route("SignIn")]
        public async Task<JsonResult> SignIn(string email, string password)
        {          
            var result = await signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            if (result.Succeeded) {

                var user = dbContext.Users
                    .Where(x => x.UserName == email)
                    .Include(x => x.Pictures)
                    .Include(x => x.UserRoles)                    
                    .ThenInclude(x => x.Role)
                    .FirstOrDefault();

                return new JsonResult(user);
            }            
            else {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to sign in user '{email}.'") });
            }
        }

        [HttpGet]
        [Route("SignOut")]
        public new async Task<JsonResult> SignOut()
        {
            try {
                await signInManager.SignOutAsync();
            }
            catch (Exception ex) {
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
        public JsonResult CreateUser(string email, string firstName, string lastName, DateTime birthdate, string password)
        {
            var existingUser = dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (existingUser != null) {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"User already exist '{email}.'") });
            }

            var user = new ApplicationUser() {
                FirstName = firstName,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                PhoneNumber = String.Empty,
                PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, password),
            };

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            this.userManager.AddToRoleAsync(user, "User");

            return new JsonResult(user);
        }
    }
}