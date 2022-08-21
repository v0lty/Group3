using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Group3.Models
{
    public class Topic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ApplicationUser Aurthor { get; set; }

        public string AurthorId { get; set; }

        public List<Subject> Subjects { get; set; }

        public int SubjectsCount { get { return Subjects != null ? Subjects.Count : 0; } }

        public List<DateTime?> PostDates
        {
            get
            {
                return Subjects != null ? // TODO: move to frontend
                       Subjects.SelectMany(x => 
                       x.Posts != null ? 
                       x.Posts.Where(x => x.EventDate != null)
                              .Select(x => x.EventDate)
                                : new List<DateTime?>()).Distinct().ToList()
                                : new List<DateTime?>();
               
            }
        }
    }
}