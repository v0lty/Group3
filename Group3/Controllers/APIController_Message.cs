using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Group3.Models;

namespace Group3.Controllers
{
    // MESSAGE RELATED FUNCTIONS

    public partial class APIController : Controller
    {
        [HttpPost]
        [Route("GetChats")]
        public JsonResult GetChats(string userId)
        {        
            var chats = dbContext.Chats
                .Include(x => x.User)
                .ThenInclude(x => x.Pictures)
                .Include(x => x.Message)
                .ThenInclude(x => x.Author)
                .ThenInclude(x => x.Pictures)
                .Where(x => x.User.Id == userId);

            var dictionary = chats
                   .OrderBy(x => x.Message.Time)
                   .ToLookup(t => t.Id, t => t.Message)
                   .Select(group => new {
                       Id = group.Key,
                       Users = dbContext.Chats
                           .Where(chat => chat.Id == group.Key && chat.User.Id != userId)
                           .Select(x => x.User)
                           .Distinct(),
                       Items = group.ToList()
                   });

            return new JsonResult(dictionary);
        }

        [HttpPost]
        [Route("CreateChatMessage")]
        public JsonResult CreateChatMessage(string text, string chatId, string 
            , string userIdArray)
        {
            var arr = userIdArray.Split(',').Append(authorId);

            if (chatId == null)
                chatId = (dbContext.Chats.OrderByDescending(x => x.Id).FirstOrDefault().Id + 1).ToString();

            foreach (string userId in arr) 
            {
                var message = new Message { Text = text, Time = DateTime.Now, AuthorId = authorId };
                dbContext.Messages.Add(message);
                dbContext.SaveChanges();
                var chat = new Chat { UserId = userId, MessageId = message.Id };
                dbContext.Chats.Add(new Chat { Id = int.Parse(chatId), UserId = userId, MessageId = message.Id });
                dbContext.SaveChanges();

            }

            return new JsonResult(null);
        }
    }
}