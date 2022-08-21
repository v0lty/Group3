using Group3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // POST RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        public DateTime FromUnixTime(long unixTimeMillis)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTimeMillis);
        }

        //[HttpPost]
        //[Route("GetPostsByDate")]
        //public JsonResult GetPostsByDate(string date)
        //{
        //    var dateTime = FromUnixTime(Int64.Parse(date));

        //    var posts = dbContext.Posts
        //        .Where(x => x.Time.Date == dateTime.Date)
        //        .Include(post => post.Author)
        //        .ThenInclude(user => user.Pictures)
        //        .Include(post => post.Author)
        //        .ThenInclude(user => user.UserRoles)
        //        .ThenInclude(role => role.Role)
        //        .Include(post => post.Pictures)
        //        .Include(post => post.Subject)
        //        .ThenInclude(subject => subject.Topic).ToArray();

        //    return new JsonResult(posts);
        //}

        [HttpGet]
        [Route("GetAllPosts")]
        public JsonResult GetAllPosts()
        {
            var posts = dbContext.Posts
                .Include(post => post.Author)
                .ThenInclude(user => user.Pictures)
                .Include(post => post.Author)
                .ThenInclude(user => user.UserRoles)
                .ThenInclude(role => role.Role)                
                .Include(post => post.Pictures)
                .Include(post => post.Subject)
                .ThenInclude(subject => subject.Topic).ToArray();

            return new JsonResult(posts);
        }

        [HttpPost]
        [Route("GetPostsBySubject")]
        public JsonResult GetPostsBySubject(string subjectId)
        {
            var posts = dbContext.Posts
                .Where(x => x.SubjectId == int.Parse(subjectId))
                .Include(post => post.Author)
                .ThenInclude(user => user.Pictures)
                .Include(post => post.Author)
                .ThenInclude(user => user.UserRoles)
                .ThenInclude(role => role.Role)
                .Include(post => post.Pictures)
                .Include(post => post.Subject)                
                .ThenInclude(subject => subject.Topic)
                .OrderBy(x => x.Time)
                .ToArray();

            return new JsonResult(posts);
        }

        [HttpPost]
        [Route("GetPostById")]
        public JsonResult GetPostById(string postId)
        {
            var post = dbContext.Posts
                .Where(x => x.Id == int.Parse(postId))
                .Include(post => post.Author)
                .ThenInclude(user => user.Pictures)
                .Include(post => post.Author)
                .ThenInclude(user => user.UserRoles)
                .ThenInclude(role => role.Role)
                .Include(post => post.Pictures)
                .Include(post => post.Subject)
                .ThenInclude(subject => subject.Topic)
                .ThenInclude(topic => topic.Category)
                .FirstOrDefault();

            return new JsonResult(post);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<JsonResult> CreatePost(string userId, string subjectId, string text)
        {
            var subject = dbContext.Subjects.Where(x => x.Id == int.Parse(subjectId)).Include(x => x.Posts).FirstOrDefault();
            var post = new Post {
                Text = text,
                Time = DateTime.Now,
                Author = await dbContext.Users.FindAsync(userId), 
                Subject = subject
            };    
            
            try {
                await dbContext.Posts.AddAsync(post);
                dbContext.SaveChanges();

                if (subject.Posts.Count == 1) {
                    await GetRSS();
                }

                return new JsonResult(post);
            }
            catch (Exception ex) {
                // Response.StatusCode != 200(OK) will raise an error in axios.post that invokes the .catch() block
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                // This sets response.data.responseText that gives more detailed info
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }

        [HttpPost]
        [Route("EditPost")]
        public async Task<JsonResult> EditPost(string postId, string postText)
        {
            try {
                var post = await dbContext.Posts.FindAsync(int.Parse(postId));
                if (post == null)
                    throw new Exception("Post not found.");

                post.Text = postText;
                dbContext.SaveChanges();

                return new JsonResult(post);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }

        [HttpPost]
        [Route("DeletePost")]
        public async Task<JsonResult> DeletePost(string postId)
        {
            try {
                var post = await dbContext.Posts.FindAsync(int.Parse(postId));
                if (post == null)
                    throw new Exception("Post not found.");

                dbContext.Posts.Remove(post);
                await dbContext.SaveChangesAsync();
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }

        [HttpPost]
        [Route("ReportPost")]
        public JsonResult ReportPost(string postId)
        {
            var post = dbContext.Posts.Where(x => x.Id == int.Parse(postId)).FirstOrDefault();
            if (post != null) {
                post.Reports++;

                dbContext.SaveChanges();
            }

            return new JsonResult(post.Reports);
        }

        [HttpPost]
        [Route("UpVotePost")]
        public JsonResult UpVotePost(string postId)
        {
            var post = dbContext.Posts.Where(x => x.Id == int.Parse(postId)).FirstOrDefault();
            if (post != null) {
                post.Votes++;
                dbContext.SaveChanges();
            }

            return new JsonResult(post.Votes);
        }

        [HttpGet]
        [Route("GetHotPosts")]
        public JsonResult GetHotPosts()
        {
            var posts = this.dbContext.Posts
                .Where(x => x.Votes > 0)
                .Include(x => x.Author)
                .ThenInclude(x => x.Pictures)
                .Include(x => x.Subject)
                .OrderByDescending(x => x.Votes)
                .Take(5)
                .ToList();

            return new JsonResult(posts);
        }

        [HttpGet]
        [Route("GetLatestPosts")]
        public JsonResult GetLatestPosts()
        {
            var posts = this.dbContext.Posts
                .Include(x => x.Author)
                .ThenInclude(x => x.Pictures)
                .Include(x => x.Subject)
                .ToList()
                .OrderByDescending(x => x.Time)
                .Take(5)
                .ToList();

            return new JsonResult(posts);
        }

        [HttpPost]
        [Route("GetPostsByDate")]
        public JsonResult GetPostsByDate(string startDate, string EndDate)
        {
            var head = DateTime.Parse(startDate);
            var tail = DateTime.Parse(EndDate);

            var posts = dbContext.Posts  // TODO: this is nasty, move events to its own database table if we find time..
                .Include(x => x.Subject)
                .ThenInclude(x => x.Posts)
                .ThenInclude(x => x.Author)
                .Include(x => x.Subject)
                .ThenInclude(x => x.Topic)
                .ThenInclude(x => x.Category)
                .Include(post => post.Author)
                .ThenInclude(user => user.UserRoles)
                .ThenInclude(role => role.Role)
                .Include(post => post.Author)
                .ThenInclude(post => post.Pictures)
                .Where(x => x.Subject.Topic.Category.Name == "News" 
                && ((x.EventDate != null 
                 && (x.EventDate >= head && x.EventDate <= tail)) 
                 || (x.Time >= head && x.Time <= tail)))                
                .OrderBy(x => x.EventDate != null ? x.EventDate : x.Time).ToList()
                .Where(x => x.Subject.Posts.OrderBy(x => x.Time).ToList().IndexOf(x) == 0).ToList();
           
            return new JsonResult(posts);
        }
    }
}