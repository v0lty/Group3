using Group3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // SUBJECT RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpPost]
        [Route("GetSubjectById")]
        public JsonResult GetSubjectById(string subjectId)
        {
            try {
                var subject = dbContext.Subjects
                    .Where(x => x.Id == int.Parse(subjectId))
                    .Include(x => x.Topic)
                    .ThenInclude(x => x.Category)
                    .Include(x => x.Posts)
                    .ThenInclude(x => x.Aurthor)
                    .ThenInclude(x => x.Pictures)
                    .Include(x => x.Posts)
                    .ThenInclude(x => x.Aurthor)
                    .ThenInclude(x => x.UserRoles)
                    .ThenInclude(x => x.Role)
                    .Include(x => x.Aurthor)
                    .ThenInclude(x => x.Posts)
                    .ThenInclude(x => x.Aurthor)
                    .ThenInclude(x => x.UserRoles)
                    .ThenInclude(x => x.Role)   
                    .FirstOrDefault();

                if (subject == null)
                    throw new Exception("Subject not found.");

                subject.Posts.Sort((x, y) => x.Time.CompareTo(y.Time));
               // subject.Subjects.ForEach(x => x.Posts.ForEach(y => y.Aurthor.Posts = dbContext.Posts.Where(z => z.Aurthor.Id == y.Aurthor.Id).ToList()));

                return new JsonResult(subject);
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
        [Route("GetHotSubjects")]
        public JsonResult GetHotSubjects()
        {
            var subjects = this.dbContext.Subjects
                .Include(x => x.Posts)
                .ToList()
                .OrderByDescending(x => x.PostsCount)
                .Take(5)
                .ToList();

            if (subjects.Count > 0) {
                subjects.Where(x => x.PostsCount == 0).ToList().ForEach(x => subjects.Remove(x));
                subjects.Sort((x, y) => x.PostsCount.CompareTo(y.PostsCount));                
            }

            return new JsonResult(subjects);
        }

        [HttpPost]
        [Route("CreateSubject")]
        public JsonResult CreateSubject(string name, string topicId)
        {
            var subject = new Subject() { 
                Name = name,
                TopicId = int.Parse(topicId) 
            };

            dbContext.Subjects.Add(subject);
            dbContext.SaveChanges();

            return new JsonResult(subject);
        }

        [HttpPost]
        [Route("DeleteSubject")]
        public async Task<JsonResult> DeleteSubject(string subjectId)
        {
            var subject = await dbContext.Subjects.FindAsync(int.Parse(subjectId));

            try
            {
                if (subject == null) {
                    throw new NullReferenceException("Subject not found!");
                }

                dbContext.Subjects.Remove(subject);
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