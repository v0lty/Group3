using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Group3.Models
{
    public class ApplicationUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<string>
    {       
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
}
