using Microsoft.AspNetCore.Identity;
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

        public String RoleString
        {
            get{ return UserRoles != null ? string.Join(",", UserRoles.Select(x => x.Role.Name).ToList()) : ""; }
        }

        public bool HasAuthority
        {
            get { return UserRoles != null ? UserRoles.Select(x => x.Role.Name).ToList().Any(x => x == "Admin" || x == "Moderator") : false; }
        }

        public List<Chat> Chats { get; set; }
    }
}
