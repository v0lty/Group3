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

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public List<Post> Posts { get; set; }

        public List<Picture> Pictures { get; set; }

        public Picture ProfilePicture { get { return (Pictures != null && Pictures.Count > 0) ? Pictures[0] : null; } }

        public String _Role
        {
            get
            {
                if (UserRoles == null)
                    return string.Empty;

                var roles = UserRoles.Select(x => x.Role.Name).ToList();                
                return string.Join(",", roles);
            }
        }
        public List<Chat> Chats { get; set; }
    }
}
