using Group3.Data;
using Group3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Group3.Controllers
{
    // Use [Authorize(Roles = "Admin")] to limit access for a certain role

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