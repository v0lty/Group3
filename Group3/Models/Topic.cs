using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class Topic
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(200, MinimumLength = 3)]
        public string Name { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public ApplicationUser Aurthor { get; set; }

        public string AurthorId { get; set; }

        public List<Post> Posts { get; set; }

        public int PostsCount { get { return Posts != null ? Posts.Count : 0; } }

        public int UpvoteCount 
        { 
            get
            {
                int totalVotes = 0;
                if (Posts != null) {
                    Posts.ForEach(post => totalVotes += post.Votes);
                }

                return totalVotes;
            }
        }
    }
}