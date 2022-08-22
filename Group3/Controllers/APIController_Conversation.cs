using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Group3.Models;

namespace Group3.Controllers
{
    // CONVERSATION RELATED FUNCTIONS
    public partial class APIController : Controller
    {
        [HttpPost]
        [Route("GetConversations")]
        public JsonResult GetConversations(string userId)
        {        
            var conversations = dbContext.Conversations
                .Include(x => x.ConversationParticipations)
                .Include(x => x.Messages)
                .ThenInclude(x => x.Author)
                .ThenInclude(x => x.Pictures)
                .Include(x => x.Messages)
                .ThenInclude(x => x.Author)
                .ThenInclude(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.ConversationParticipations.Any(x => x.UserId == userId));

            return new JsonResult(conversations);
        }

        [HttpPost]
        [Route("CreateConversation")]
        public JsonResult CreateConversation(string authorId, string userIds)
        {
            var conversation = new Conversation() { };

            dbContext.Conversations.Add(conversation);
            dbContext.SaveChanges();

            foreach (var id in userIds.Split(','))
            {
                var participation = new ConversationParticipation() { ConversationId = conversation.Id, UserId = id };
                dbContext.ConversationParticipations.Add(participation);
                dbContext.SaveChanges();
            }

            return new JsonResult(conversation);
        }

        [HttpPost]
        [Route("CreateConversationMessage")]
        public JsonResult CreateConversationMessage(string conversationId, string authorId, string text)
        {
            var conversation = dbContext.Conversations
                .Include(x => x.ConversationParticipations)
                .Where(x => x.Id == int.Parse(conversationId))
                .FirstOrDefault();

            if (conversation == null)  {
                Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return new JsonResult(new { Success = "False", responseText = "Conversation not found." });
            }

            var message = new Message() { ConversationId = conversation.Id, AuthorId = authorId, Text = text, Time = DateTime.Now };

            dbContext.Messages.Add(message);
            dbContext.SaveChanges();

            return new JsonResult(message);
        }

        [HttpPost]
        [Route("DeleteConversationMessage")]
        public JsonResult DeleteConversationMessage(string messageId)
        {
            var message = dbContext.Messages.Where(x => x.Id == int.Parse(messageId)).FirstOrDefault();            
            if (message != null) {

                var conversationId = message.ConversationId;

                dbContext.Messages.Remove(message);
                dbContext.SaveChanges();

                var conversation = dbContext.Conversations
                    .Include(x => x.Messages)
                    .Include(x => x.ConversationParticipations)
                    .Where(x => x.Id == conversationId).FirstOrDefault();

                if (conversation != null)
                {
                    if (conversation.Messages.Count == 0) {
                        // delete last message -> delete conversation aswell..
                        dbContext.ConversationParticipations.RemoveRange(conversation.ConversationParticipations);                    
                        dbContext.Conversations.Remove(conversation);
                        dbContext.SaveChanges();
                    }
                }
            }

            return new JsonResult(null);
        }
    }
}