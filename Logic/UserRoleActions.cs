using CurryLounge.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurryLounge.Logic
{
    internal class UserRoleActions
    {
        internal void AddUserAndRole()
        {
            Models.ApplicationDbContext c = new ApplicationDbContext();
            IdentityResult roleIdResult;
            IdentityResult userIdResult;

            var resturantRole = new RoleStore<IdentityRole>(c);

            var managerRole = new RoleManager<IdentityRole>(resturantRole);

            if (!managerRole.RoleExists("hasAdmin"))
            {
                roleIdResult = managerRole.Create(new IdentityRole { Name = "hasAdmin" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(c));
            var user = new ApplicationUser
            {
                UserName = "hasAdmin@currylounge.com",
                Email = "hasAdmin@currylounge.com"
            };
            userIdResult = userManager.Create(user, "PA$$W0RD");

            if (!userManager.IsInRole(userManager.FindByEmail("hasAdmin@currylounge.com").Id, "hasAdmin"))
            {
                userIdResult = userManager.AddToRole(userManager.FindByEmail("hasAdmin@currylounge.com").Id, "hasAdmin");
            }
        }
    }
}