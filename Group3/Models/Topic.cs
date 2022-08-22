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

        public List<Subject> Subjects { get; set; }

        public int SubjectsCount { get { return Subjects != null ? Subjects.Count : 0; } }

        public List<DateTime?> PostDates
        {
            get
            {
                var list = Subjects != null ?
                           Subjects
                           .SelectMany(x => x.Posts != null
                                           ? x.Posts
                                           .Select(x => x.EventDate)
                                           : new List<DateTime?>()).Distinct().ToList()
                                           : new List<DateTime?>();

                list.RemoveAll(item => item == null);
                return list;
            }
        }

        public List<Post> GetPostsByDate(DateTime startDate, DateTime endDate)
        {
            var result = new List<Post>();

            if (Subjects != null)
                Subjects.ForEach(subject => result.AddRange(subject.GetPostsByDate(startDate, endDate)));

            return result;
        }
    }
}