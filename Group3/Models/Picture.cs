using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Group3.Models
{
    public class Picture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Path { get; set; }

        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Key, ForeignKey("Post")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

    }
}
