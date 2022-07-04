using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Group3.Models
{
    public class AdminViewModel
    {
        public RoleManager<ApplicationRole> RoleManager { get; private set; }
        public UserManager<ApplicationUser> UserManager { get; private set; }

        public IEnumerable<ApplicationUser> Users 
        {
            get { return UserManager.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).AsNoTracking(); } 
        }

        public IEnumerable<ApplicationRole> Roles
        {
            get { return RoleManager.Roles.Include(u => u.UserRoles).ThenInclude(ur => ur.User).AsNoTracking(); }
        }

        public AdminViewModel(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.RoleManager = roleManager;
            this.UserManager = userManager;
        }
    }
}
