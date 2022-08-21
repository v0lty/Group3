using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class Conversation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public List<ConversationParticipation> ConversationParticipations { get; set; }

        public List<Message> Messages { get; set; }
    }
}
