using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Group3.Controllers
{
    // MESSAGE RELATED FUNCTIONS

    public partial class APIController : Controller
    {
        [HttpPost]
        [Route("GetChats")]
        public JsonResult GetChats(string userId)
        {
            var user = dbContext.Users
                .Where(x => x.Id == userId)
                .Include(x => x.Chats)
                .ThenInclude(x => x.Message)
                .ThenInclude(x => x.Aurthor)
                .FirstOrDefault();

            var dictionary = user.Chats
                   .OrderBy(x => x.Message.Time)
                   .ToLookup(t => t.Id, t => t.Message)
                   .Select(group => new {
                       Users = dbContext.Chats
                           .Where(chat => chat.Id == group.Key)
                           .Select(x => x.User)
                           .Distinct(),
                       Items = group.ToList()
                   });

            return new JsonResult(dictionary);
        }
    }
}