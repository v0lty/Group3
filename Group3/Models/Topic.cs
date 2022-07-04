using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Models
{
    public class Topic
    {

        [Key]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string TopicName { get; set; }

        [StringLength(10000, MinimumLength = 1)]
        public string Text { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ApplicationUser User { get; set; }

        public int UserId { get; set; }

        public List<Post> Posts { get; set; }



 


    }
}
