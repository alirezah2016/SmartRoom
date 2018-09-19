using Microsoft.AspNet.Identity.EntityFramework;
using SmartRoom.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SmartRoom.Web.Infrastructurs
{
    public class AppIdentityDBContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDBContext() : base("SmartroomDB") { }
        static AppIdentityDBContext()
        {
            Database.SetInitializer<AppIdentityDBContext>(new IdentityDbInit());
        }
        public static AppIdentityDBContext Create()
        {
            return new AppIdentityDBContext();
        }
    }

    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDBContext>
    {
        protected override void Seed(AppIdentityDBContext context)
        {
            base.Seed(context);
        }
        public void PerformInitialSetup()
        {

        }
    }
}