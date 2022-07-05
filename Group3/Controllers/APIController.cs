using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Group3.Data;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

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

            var posts = dbContext.Posts.Include(post => post.User).Include(post => post.Topic).ToArray()
                .Select(post => 
                new
                {
                    post.Id,
                    post.Time,
                    post.Text
                }).ToArray();

            var postdata = JsonSerializer.Serialize(posts, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,

            });
            

            return new JsonResult(postdata);
        }
    }
}
