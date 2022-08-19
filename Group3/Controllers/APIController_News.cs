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

        // For right sidebar Next Events top list
        [HttpGet]
        [Route("GetNextEvents")]
        public JsonResult GetNextEvents()
        {
            var topic = this.dbContext.Topics
                .Where(topic => topic.Name == "Events")
                .Include(topic => topic.Subjects)
                .ThenInclude(subject => subject.Posts)
                .FirstOrDefault();

            return new JsonResult(topic);
        }

        [HttpPost]
        [Route("CreateEvet")]
        public async Task<JsonResult> CreateEvent(string userId, string subjectId, string text, DateTime eventdate)
        {
            var subject = dbContext.Subjects.Where(x => x.Id == int.Parse(subjectId)).Include(x => x.Posts).FirstOrDefault();
            var post = new Post
            {
                Text = text,
                Time = DateTime.Now,
                Aurthor = await dbContext.Users.FindAsync(userId),
                Subject = subject,
                EventDate = eventdate
            };

            try
            {
                await dbContext.Posts.AddAsync(post);
                dbContext.SaveChanges();

                if (subject.Posts.Count == 1)
                {
                    await GetRSS();
                }

                return new JsonResult(post);
            }
            catch (Exception ex)
            {
                // Response.StatusCode != 200(OK) will raise an error in axios.post that invokes the .catch() block
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                // This sets response.data.responseText that gives more detailed info
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }

    }
}