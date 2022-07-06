using System;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [StringLength(10000, MinimumLength = 1)]
        public string Text { get; set; }

        public DateTime Time { get; set; }

        public Topic Topic { get; set; }

        public string TopicId { get; set; }

        public string ReferenceId { get; set; }

        public Post Reference { get; set; }

    }
}