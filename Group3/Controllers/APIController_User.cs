﻿using Group3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // USER RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        public ApplicationUser CurrentUser
        { 
            get { return dbContext.Users.Include(u => u.Posts).Where(x => x.UserName == User.Identity.Name).FirstOrDefault(); }
        }

        [HttpGet]
        [Route("GetUser")]
        public JsonResult GetUser()
        {
            return new JsonResult(CurrentUser);
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<JsonResult> SignIn(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            if (result.Succeeded) {
                // User is null untill redirect that force cookie to update
                // https://stackoverflow.com/questions/54706650/null-reference-exception-for-claimstype-in-identitycore-getting-claims-as-null
                var user = dbContext.Users.Where(x => x.UserName == email).Select(user => new { // await userManager.FindByEmailAsync(email);
                        user.Id,
                        user.Name,
                        user.UserName,
                        Birthdate = user.Birthdate.ToShortDateString(),
                        user.Email
                    }).FirstOrDefault();

                var userdata = JsonSerializer.Serialize(user, new JsonSerializerOptions() {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true,
                });        

                return new JsonResult(userdata);
            }            
            else {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = string.Format($"Failed to sign in user '{email}.'") });
            }
        }
    }
}