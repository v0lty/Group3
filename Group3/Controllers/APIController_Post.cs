using Group3.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // POST RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetAllPosts")]
        public JsonResult GetAllPosts()
        {
            var posts = dbContext.Posts
                .Include(post => post.User)
                .Include(post => post.Topic)
                .ThenInclude(topic => topic.Category).ToArray()
                .Select(post => new {
                    post.Id,
                    Time = post.Time.ToString("g"),
                    post.Text,
                    User = new {
                        post.User,
                        post.User.Id,
                        post.User.UserName,
                        post.User.Name,
                    },
                    Topic = new {
                        post.Topic.Id,
                        post.Topic.Name,
                        Category = new {
                            post.Topic.Category.Id,
                            post.Topic.Category.Name,
                        }
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
        public async Task<JsonResult> CreatePost(string userId, string topicId, string text)
        {
            var post = new Post {
                Text = text,
                Time = DateTime.Now,
                User = await dbContext.Users.FindAsync(userId), 
                Topic = await dbContext.Topics.FindAsync(int.Parse(topicId))
            };        

            try {
                await dbContext.Posts.AddAsync(post);
                dbContext.SaveChanges();
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
        [Route("DeletePost")]
        public async Task<JsonResult> DeletePost(string postId)
        {
            try {
                var post = await dbContext.Posts.FindAsync(int.Parse(postId));
                if (post == null)
                    throw new Exception("Post not found.");

                dbContext.Posts.Remove(post);
                dbContext.SaveChanges();
                return new JsonResult(null);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }
        }
    }
}