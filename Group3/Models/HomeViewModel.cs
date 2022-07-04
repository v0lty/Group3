using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using Group3.Data;

namespace Group3.Models
{
    public class HomeViewModel
    {
        public ApplicationDbContext Context { get; set; }

        public ClaimsPrincipal Principal { get; set; }

        public ApplicationUser CurrentUser 
        { 
            get 
            { 
                return Context.Users.Include(u => u.Messages)
                                    .ThenInclude(u => u.User)
                                    .Include(u => u.Messages)
                                    .ThenInclude(u => u.Receiver)
                                    .Include(u => u.Posts).Where(x => x.UserName == Principal.Identity.Name).FirstOrDefault(); 
            } 
        }

        public IEnumerable<Category> Categories
        {
            get { return Context.Categories.Include(u => u.Topics).ThenInclude(u => u.Posts).ThenInclude(u => u.User); }
        }

        public HomeViewModel(ApplicationDbContext dbContext, ClaimsPrincipal claimsPrincipa)
        {
            Context = dbContext;
            Principal = claimsPrincipa;
        }
    }
}
