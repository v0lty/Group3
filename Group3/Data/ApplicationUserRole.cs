namespace Group3.Models
{
    public class ApplicationUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<string>
    {       
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
