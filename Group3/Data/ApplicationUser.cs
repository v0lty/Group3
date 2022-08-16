﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        [StringLength(50, MinimumLength = 2)]
        public String Location { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public List<Post> Posts { get; set; }

        public int PostsCount { get { return Posts != null ? Posts.Count : 0; } }

        public List<Picture> Pictures { get; set; }

        public virtual List<UserGroupEnlistment> UserGroupEnlistments { get; set; }

        public Picture ProfilePicture { get { return (Pictures != null && Pictures.Count > 0) ? Pictures[0] : null; } }

        public List<String> Roles
        {
            get { return UserRoles != null ? UserRoles.Select(x => x.Role.Name).ToList() : new List<string>(); }
        }

        public String RoleString
        {
            get{ return string.Join(",", Roles); }
        }

        public bool HasAuthority
        {
            get { return Roles.Any(x => x == "Admin" || x == "Moderator") ? true : false; }
        }

        public bool IsAdmin
        {
            get { return Roles.Any(x => x == "Admin") ? true : false; }
        }

        public List<Chat> Chats { get; set; }

        public List<UserGroup> UserGroups { get; set; }
    }
}
