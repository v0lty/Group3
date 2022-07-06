using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Group3.Controllers
{
    // TOPIC RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetAllTopics")]
        public JsonResult GetAllTopics()
        {
            var posts = this.dbContext.Topics
                .Include(topic => topic.Posts)
                .ThenInclude(post => post.User).ToArray()
                .Select(topic => new {
                    topic.Id,
                    topic.Name,
                    topic.Description
                }).ToArray();

            var topicdata = JsonSerializer.Serialize(posts, new JsonSerializerOptions()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
            });

            return new JsonResult(topicdata);
        }
    }
}