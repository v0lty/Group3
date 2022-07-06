using Group3.Data;
using Group3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace Group3.Controllers
{
    // CONSTRUCTOR & GENERAL
    [ApiController]
    [Route("[controller]")]
    public partial class APIController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public APIController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.dbContext = context;
            this.userManager = userManager;
            this.signInManager = signInManager;            
        }

        /* TODO:
         * GetPostByID
         * EditPost
         * RemovePost
         * CreateTopic
         * EditTopic
         * RemoveTopic
         * CreatCategory
         */
    }
}