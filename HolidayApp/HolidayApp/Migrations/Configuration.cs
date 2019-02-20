namespace HolidayApp.Migrations
{
    using HolidayApp.Entities;
    using HolidayApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HolidayApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HolidayApp.Models.ApplicationDbContext";
        }

        protected override void Seed(HolidayApp.Models.ApplicationDbContext context)
        {


          

            base.Seed(context);


        }
    }
   
}
