﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Group3.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get { return string.Format($"{FirstName} {LastName}"); } }

        [Required, Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required, Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public List<Post> Posts { get; set; }

        public List<Picture> Pictures { get; set; }

        public List<Chat> Chats { get; set; }
    }
}
