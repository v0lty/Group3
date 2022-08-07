using Group3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Controllers
{
    // MESSAGE RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpGet]
        [Route("GetAllCategories")]
        public JsonResult GetAllCategories()
        {
            var categories = this.dbContext.Categories
                .Include(cat => cat.Topics)
                .ThenInclude(topic => topic.Subjects)
                .ToArray();
            return new JsonResult(categories);
        }

        [HttpPost]
        [Route("GetCategoryById")]
        public JsonResult GetCategoryById(string categoryId)
        {
            try {
                var category = dbContext.Categories
                    .Where(x => x.Id == int.Parse(categoryId))
                    .Include(x => x.Topics)
                    .FirstOrDefault();

                if (category == null)
                    throw new Exception("Category not found.");

                return new JsonResult(category);
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