using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class Topic
    {
        [Key]
        public string Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public string CategoryId { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public List<Post> Posts { get; set; }
    }
}