using Group3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // NEWS RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetEvents")]
        public JsonResult GetEvents()
        {
            var events = this.dbContext.Topics
                .Where(x => x.Name == "Events")
                .Include(x => x.Subjects)
                .ThenInclude(x => x.Posts)
                .FirstOrDefault();

            return new JsonResult(events);
        }
    }
}
