using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Group3.Controllers
{
    // TOPIC RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetAllTopics")]
        public JsonResult GetAllTopics()
        {
            var topics = this.dbContext.Topics
                .Include(topic => topic.Posts)
                .ThenInclude(post => post.User).ToArray();

            return new JsonResult(topics);
        }
    }
}