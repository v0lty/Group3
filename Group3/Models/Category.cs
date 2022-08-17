using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public List<Topic> Topics { get; set; }

        public int UserGroupId { get; set; }

        public UserGroup UserGroup { get; set; }

        public int TopicsCount { get { return Topics != null ? Topics.Count : 0; } }        
    }
}