using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class Post
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AurthorId { get; set; }

        public ApplicationUser Aurthor { get; set; }

        [StringLength(10000, MinimumLength = 1)]
        public string Text { get; set; }

        public DateTime Time { get; set; }

        public Topic Topic { get; set; }

        public int TopicId { get; set; }

        public List<Picture> Pictures { get; set; }

        public int? ReferenceId { get; set; }

        public Post Reference { get; set; }
    }
}