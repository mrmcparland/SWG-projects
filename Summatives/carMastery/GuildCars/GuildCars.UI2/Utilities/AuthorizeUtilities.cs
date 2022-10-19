using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using GuildCars.UI2.Models;

namespace GuildCars.UI2.Utilities
{
    public class AuthorizeUtilities
    {
        public static string GetUserId(Controller controller)
        {
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userMgr.FindByName(controller.User.Identity.Name);
            return user.Id;
        }
    }
}