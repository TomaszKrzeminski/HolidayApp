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


            List<Resort> resortList = new List<Resort>();
            resortList.Add(new Resort() {ResortId=1, Name= "Resort Władysławowo", City="Władysławowo",Country="Poland",TelephoneNumber=794219756 });
            resortList.Add(new Resort() {ResortId=2, Name = "Resort Sopot", City = "Sopot", Country = "Poland", TelephoneNumber = 794219755 });
            resortList.Add(new Resort() {ResortId=3, Name = "Resort Gdańsk", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });

            resortList.ForEach(x => context.Resorts.Add(x));
            context.SaveChanges();

            List<Hotel> hotelList = new List<Hotel>();
            hotelList.Add(new Hotel (){HotelId=1, Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            hotelList.Add(new Hotel() {HotelId=2, Name = "Hotel Warszawa", City = "Warszawa", Country = "Poland", TelephoneNumber = 777888555 });
            hotelList.Add(new Hotel() {HotelId=3, Name = "Hotel Katowice", City = "Katowice", Country = "Poland", TelephoneNumber = 777888444 });

            hotelList.ForEach(y => context.Hotels.Add(y));
            context.SaveChanges();




            List<Parking> parkingList = new List<Parking>();
            parkingList.Add(new Parking() {Guarded=true,parkingPlaces=10,pricePerDay=10m,HotelId=1 });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 100, pricePerDay = 20m, HotelId = 2 });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 20, pricePerDay = 0m, HotelId = 3 });

            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 10, pricePerDay = 10m, ResortId = 1 });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 20, pricePerDay = 20m, ResortId = 2 });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 30, pricePerDay = 0m, ResortId = 3 });

            parkingList.ForEach(z => context.Parkings.Add(z));


            List<Room> roomList = new List<Room>();



            List<HolidayHome> homesList = new List<HolidayHome>();








            List<IntermediateCategory> defaultIntermediateCategories = new List<IntermediateCategory>();

            for (int i = 1; i < 9; i++)
            {


                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Zdrowie", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Kuchnia", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Sport ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Kino ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Polityka ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Rodzina ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Dom i Ogród ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Praca ", MainCategoryByCitiesId = i });
                defaultIntermediateCategories.Add(new IntermediateCategory { NameOfMainCategory = "Towarzyskie ", MainCategoryByCitiesId = i });

            }




            defaultIntermediateCategories.ForEach(x => context.IntermediateCategories.Add(x));
            context.SaveChanges();







            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //string[] roleNames = new string[] { "Administrator", "Owner","Client" };
            //IdentityResult roleResult;
            //foreach (var roleName in roleNames)
            //{
            //    if (!roleManager.RoleExists(roleName))
            //    {
            //        roleResult = roleManager.Create(new IdentityRole(roleName));
            //    }
            //}

            //context.SaveChanges();

            //if (!context.Users.Any(u => u.UserName == "koral2323@gmail.com"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "koral2323@gmail.com" };
            //    user.Email = "koral2323@gmail.com";


            //    manager.Create(user, "Daria21081985@");
            //    manager.AddToRole(user.Id, "Administrator");
            //}

            //context.SaveChanges();




           


           








            






            base.Seed(context);


        }
    }
    }
}
