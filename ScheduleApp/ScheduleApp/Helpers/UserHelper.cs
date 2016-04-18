using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScheduleApp.Models;

namespace ScheduleApp.Helpers
{
    public class UserHelper
    {
        private static ApplicationDbContext context = new ApplicationDbContext();

        private static RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
        private static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
        private static UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
        private static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);

        public static bool BelongsToAdminRole(string userName)
        {
//            ApplicationDbContext context = new ApplicationDbContext();
//
//            var roleStore = new RoleStore<IdentityRole>(context);
//            var roleManager = new RoleManager<IdentityRole>(roleStore);
//            var userStore = new UserStore<ApplicationUser>(context);
//            var userManager = new UserManager<ApplicationUser>(userStore);
            try
            {
                var user = userManager.FindByName(userName);
                return userManager.IsInRole(user.Id, "Admin");
            }
            catch (Exception ex)
            {
                return false;
            }
            
        } 
    }
}