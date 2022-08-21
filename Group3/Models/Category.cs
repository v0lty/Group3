using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        
        public List<DateTime> PostDates
        {
            get
            {
                return Topics != null // TODO: move events to its own table and get PostDates in frontend instead
                     ? Topics.Where(x => x.Name != "Events").SelectMany(x =>
                        x.Subjects != null 
                      ? x.Subjects.SelectMany(
                          x => x.Posts != null 
                        ? x.Posts.Where(x => x.Subject.Posts.OrderBy(x => x.Time).ToList().IndexOf(x) == 0).Select(x => x.Time)
                        : new List<DateTime>()) 
                      : new List<DateTime>()).Distinct().ToList()
                     : new List<DateTime>();
            }
        }
    }
}