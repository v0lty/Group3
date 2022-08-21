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
                .Include(topic => topic.Subjects)
                .ThenInclude(post => post.Author).ToArray();

            return new JsonResult(topics);
        }

        [HttpPost]
        [Route("GetTopicById")]
        public JsonResult GetTopicById(string topicId)
        {
            try {
                var topic = dbContext.Topics
                    .Where(x => x.Id == int.Parse(topicId))
                    .Include(x => x.Category)
                    .Include(x => x.Subjects)
                    .ThenInclude(x => x.Author)
                    .ThenInclude(x => x.Pictures)
                    .Include(x => x.Subjects)
                    .ThenInclude(x => x.Posts)
                    .ThenInclude(x => x.Author)
                    .ThenInclude(x => x.UserRoles)
                    .ThenInclude(x => x.Role)                    
                    .FirstOrDefault();

                topic.Subjects.ForEach(x => x.Posts.Sort((x, y) => x.Time.CompareTo(y.Time)));
                topic.Subjects.ForEach(x => x.Posts.ForEach(y => y.Author.Posts = dbContext.Posts.Where(z => z.Author.Id == y.Author.Id).ToList()));

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

        [HttpGet]
        [Route("GetHotTopics")]
        public JsonResult GetHotTopics()
        {
            var topics = this.dbContext.Topics
                .Include(x => x.Subjects)
                .ThenInclude(x => x.Posts)
                .ToList()
                .OrderByDescending(x => x.SubjectsCount)
                .Take(5)
                .ToList();

            if (topics != null 
             && topics.Count > 0) {
                topics.Where(x => x.SubjectsCount == 0).ToList().ForEach(x => topics.Remove(x));
                topics.Sort((x, y) => x.Subjects.Count.CompareTo(y.Subjects.Count));                
            }

            return new JsonResult(topics);
        }

        [HttpPost]
        [Route("CreateTopic")]
        public JsonResult CreateTopic(string name, string description, string categoryId)
        {
            var topic = new Topic() { 
                Name = name,
                Description = description,
                CategoryId = int.Parse(categoryId) 
            };

            dbContext.Topics.Add(topic);
            dbContext.SaveChanges();

            return new JsonResult(topic);
        }

        [HttpPost]
        [Route("DeleteTopic")]
        public async Task<JsonResult> DeleteTopic(string topicId)
        {
            var topic = await dbContext.Topics.FindAsync(int.Parse(topicId));

            try
            {
                if (topic == null) {
                    throw new NullReferenceException("Topic not found!");
                }

                dbContext.Topics.Remove(topic);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.NotFound;
                return new JsonResult(new { Success = "False", responseText = ex.Message });
            }

            return new JsonResult(null);
        }
    }
}