using Group3.Data;
using Microsoft.AspNetCore.Mvc;

namespace Group3.Controllers
{
    // CONSTRUCTOR & GENERAL
    [ApiController]
    [Route("[controller]")]
    public partial class APIController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public APIController(ApplicationDbContext Context)
        {
            this.dbContext = Context;
        }

        /* TODO:
         * GetPostByID
         * EditPost
         * RemovePost
         * CreateTopic
         * EditTopic
         * RemoveTopic
         * CreatCategory
         */
    }
}