using Group3.Data;
using Group3.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
        private readonly IWebHostEnvironment hostEnvironment;

        public APIController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IWebHostEnvironment environment)
        {
            this.dbContext = context;
            this.hostEnvironment = environment;
            this.userManager = userManager;
            this.signInManager = signInManager;            
        }
    }
}