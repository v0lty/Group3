using Group3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // USER RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        /// <summary>
        /// Check if a User cookie exist before attempting to Sign in. No error should be thrown here.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("QueryCurrentUser")]       
        public JsonResult QueryCurrentUser()
        {           
            var user = dbContext.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null) {

                var userdata = JsonSerializer.Serialize(user, new JsonSerializerOptions() {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true,
                });

                return new JsonResult(userdata);
            }

            return new JsonResult(null);
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<JsonResult> SignIn(string email, string password)
        {          
            var result = await signInManager.PasswordSignInAsync(email, password, true, lockoutOnFailure: false);
            if (result.Succeeded) {
                // User is null untill redirect that force cookie to update
                // https://stackoverflow.com/questions/54706650/null-reference-exception-for-claimstype-in-identitycore-getting-claims-as-null
                var user = dbContext.Users
                    .Where(x => x.UserName == email)
                    .Include(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Select(user => new { 
                        user.Id,
                        user.Name,
                        user.UserName,
                        Birthdate = user.Birthdate.ToShortDateString(),
                        user.Email,
                        Roles = user.UserRoles.Select(role => new {
                            role.Role.Id,
                            role.Role.Name,                            
                        })
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
    }
}