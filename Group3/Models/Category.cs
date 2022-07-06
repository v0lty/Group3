using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class Category
    {
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 1)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Text { get; set; }

        public List<Topic> Topics { get; set; }
    }
}