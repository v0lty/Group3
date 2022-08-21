using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Group3.Models
{
    public class Subject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public string UrlSlug { get; set; }

        public Topic Topic { get; set; }

        public int TopicId { get; set; }

        public ApplicationUser Author { get; set; }

        public string AuthorId { get; set; }

        public List<Post> Posts { get; set; }

        public int PostsCount { get { return Posts != null ? Posts.Count : 0; } }

        public Post FirstOrDefaultPost { get { return Posts != null ? Posts.FirstOrDefault() : null; } }

        public int TotalPostsVoteCount
        {
            get
            {
                int totalVotes = 0;
                if (Posts != null)            
                    Posts.ForEach(post => totalVotes += post.Votes);             

                return totalVotes;
            }
        }

        public List<Post> GetPostsByDate(DateTime startDate, DateTime endDate)
        {
            return Posts != null 
                 ? Posts.Where(post => post.Time >= startDate && post.Time <= endDate).ToList() 
                 : new List<Post>();
        }
    }
}