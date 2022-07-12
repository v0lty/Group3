using Group3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("GetTopicById")]
        public JsonResult GetTopicById(string topicId)
        {
            try {
                var topic = dbContext.Topics
                    .Where(x => x.Id == int.Parse(topicId))
                    .Include(x => x.Posts)
                    .FirstOrDefault();

                if (topic == null)
                    throw new Exception("Topic not found.");

                return new JsonResult(topic);
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