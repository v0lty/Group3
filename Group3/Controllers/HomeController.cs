using Microsoft.AspNetCore.Mvc;

using Group3.Data;
using Group3.Models;

namespace Group3.Controllers
{
    public class HomeController : Controller
    {
        protected ApplicationDbContext Context { get; set; }       

        public HomeController(ApplicationDbContext context)
        {
            Context = context;
        }
        
        public IActionResult Index()
        {
            return View(new HomeViewModel(Context, User));
        }
    }
}