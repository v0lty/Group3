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
        [Route("GetNews")]
        public JsonResult GetNews()
        {
            var category = this.dbContext.Categories
                .Where(x => x.Name == "News")
                .Include(x => x.Topics)
                .ThenInclude(x => x.Subjects)
                .ThenInclude(x => x.Posts)
                .ThenInclude(x => x.Aurthor)
                .FirstOrDefault();

            return new JsonResult(category);
        }

        // For right sidebar Last News top list
        [HttpGet]
        [Route("GetLatestNews")]
        public JsonResult GetLatestNews()
        {
            var category = this.dbContext.Categories
                .Where(category => category.Name == "News")
                .Include(category => category.Topics)
                .ThenInclude(topic => topic.Subjects)
                .ThenInclude(subject => subject.Posts)
                .FirstOrDefault();

            return new JsonResult(category);
        }
    }
}