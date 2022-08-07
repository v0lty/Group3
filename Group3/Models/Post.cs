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

        public Subject Subject { get; set; }

        public int SubjectId { get; set; }

        public List<Picture> Pictures { get; set; }

        public int Reports { get; set; }

        public int Votes { get; set; }
    }
}