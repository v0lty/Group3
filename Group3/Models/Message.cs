using System;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class Message 
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string ReceiverId { get; set; }

        public ApplicationUser Receiver { get; set; }

        [StringLength(10000, MinimumLength = 1)]
        public string Text { get; set; }

        public DateTime Time { get; set; }
    }
}
