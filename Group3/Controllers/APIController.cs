using Group3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Group3.Models;

namespace Group3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class APIController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public APIController(ApplicationDbContext Context)
        {
            this.dbContext = Context;
        }

        [HttpGet]
        [Route("GetAllPosts")]
        public JsonResult GetAllPosts()
        {
            var posts = dbContext.Posts
                .Include(post => post.User)
                .Include(post => post.Topic).ToArray()
                .Select(post => new {
                    post.Id,
                    post.Time,
                    post.Text,
                    User = new {
                        post.User,
                        post.User.Id,
                        post.User.UserName,
                        post.User.Name,
                    },
                    Topic = new {
                        post.Topic.Id,
                        post.Topic.Name
                    }
                }).ToArray();

            var postdata = JsonSerializer.Serialize(posts, new JsonSerializerOptions() {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
            });            

            return new JsonResult(postdata);
        }

        [HttpPost]
        [Route("CreatePost")]
        public async Task<JsonResult> CreatePost(string text) // todo: int UserId, int TopicId
        {
            var post = new Post {
                Text = text,
                Time = DateTime.Now,
                User = dbContext.Users.ToArray()[new Random().Next(0, dbContext.Users.Count<ApplicationUser>())], 
                Topic = dbContext.Topics.ToArray()[new Random().Next(0, dbContext.Topics.Count<Topic>())] 
            };        

            try {
                await dbContext.Posts.AddAsync(post);
                dbContext.SaveChanges();
                return new JsonResult(post);
            }
            catch (Exception ex) {
                // StatusCode != 200(OK) will raise an error in axios.post that invokes the catch() block
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                // This sets response.data.responseText that gives more detailed info
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }

        /*
         * GetPostByID
         * EditPost
         * RemovePost
         * 
         * CreateTopic
         * EditTopic
         * RemoveTopic
         * 
         * CreatCategory
         * 
         */
    }
}