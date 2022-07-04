using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Group3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 3)]
        public virtual string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 3)]
        public virtual string LastName { get; set; }

        [Required, Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public virtual DateTime Birthdate { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
