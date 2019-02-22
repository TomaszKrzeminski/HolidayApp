using HolidayApp.Entities;
using HolidayApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HolidayApp.Seed
{
    public class HolidayAppDbInitializer: DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {


        protected override void Seed(ApplicationDbContext context)
        {



            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            string[] roleNames = new string[] { "Administrator", "Owner", "Client" };
            IdentityResult roleResult;
            foreach (var roleName in roleNames)
            {
                if (!roleManager.RoleExists(roleName))
                {
                    roleResult = roleManager.Create(new IdentityRole(roleName));
                }
            }

            

            if (!context.Users.Any(u => u.UserName == "koral2323@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "koral2323@gmail.com" };
                user.Email = "koral2323@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Administrator");
            }



            if (!context.Users.Any(u => u.UserName == "1OwnerWladyslawowo@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "1OwnerWladyslawowo@gmail.com" };
                user.Email = "1OwnerWladyslawowo@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }
            
            if (!context.Users.Any(u => u.UserName == "2OwnerSopot@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "2OwnerSopot@gmail.com" };
                user.Email = "2OwnerSopot@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }
            if (!context.Users.Any(u => u.UserName == "3OwnerGdansk@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "3OwnerGdansk@gmail.com" };
                user.Email = "3OwnerGdansk@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }
            if (!context.Users.Any(u => u.UserName == "4OwnerKrakow@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "4OwnerKrakow@gmail.com" };
                user.Email = "4OwnerKrakow@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }
            if (!context.Users.Any(u => u.UserName == "5OwnerWarszawa@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "5OwnerWarszawa@gmail.com" };
                user.Email = "5OwnerWarszawa@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }
            if (!context.Users.Any(u => u.UserName == "6OwnerKatowice@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "6OwnerKatowice@gmail.com" };
                user.Email = "6OwnerKatowice@gmail.com";


                manager.Create(user, "Daria21081985@");
                manager.AddToRole(user.Id, "Owner");
            }








            context.SaveChanges();



           




            List<Resort> resortList = new List<Resort>();
            resortList.Add(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            resortList.Add(new Resort() { Name = "Resort Sopot", City = "Sopot", Country = "Poland", TelephoneNumber = 794219755 });
            resortList.Add(new Resort() { Name = "Resort Gdańsk", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });

            resortList.ForEach(x => context.Resorts.Add(x));

          

          





            List<Hotel> hotelList = new List<Hotel>();
            hotelList.Add(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            hotelList.Add(new Hotel() { Name = "Hotel Warszawa", City = "Warszawa", Country = "Poland", TelephoneNumber = 777888555 });
            hotelList.Add(new Hotel() { Name = "Hotel Katowice", City = "Katowice", Country = "Poland", TelephoneNumber = 777888444 });

            hotelList.ForEach(y => context.Hotels.Add(y));



            List<ApplicationUser> userList = new List<ApplicationUser>();

            userList.AddRange(context.Users.OrderBy(x => x.Email).Take(6));


            for (int i = 0; i < 3; i++)
            {
                userList[i].Resorts.Add(resortList[i]);
            }

            for (int i = 0; i <3; i++)
            {
                userList[i+3].Hotels.Add(hotelList[i]);
            }


            context.SaveChanges();


            List<Parking> parkingList = new List<Parking>();
            parkingList.Add(new Parking() { Guarded = true, parkingPlaces = 10, pricePerDay = 10m });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 100, pricePerDay = 20m });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 20, pricePerDay = 0m });

            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 10, pricePerDay = 10m });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 20, pricePerDay = 20m });
            parkingList.Add(new Parking() { Guarded = false, parkingPlaces = 30, pricePerDay = 0m });


            for (int i = 0; i < 3; i++)
            {
                context.Parkings.Add(parkingList[i]);
            }



            context.Resorts.Find(1).Parkings.Add(parkingList[0]);
            context.Resorts.Find(2).Parkings.Add(parkingList[1]);
            context.Resorts.Find(3).Parkings.Add(parkingList[2]);
           

            context.SaveChanges();


            for (int i = 3; i < 6; i++)
            {
                context.Parkings.Add(parkingList[i]);
            }


            context.Hotels.Find(1).Parkings.Add(parkingList[3]);
            context.Hotels.Find(2).Parkings.Add(parkingList[4]);
            context.Hotels.Find(3).Parkings.Add(parkingList[5]);


            context.SaveChanges();


            List<Room> roomList = new List<Room>();
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });

            roomList.ForEach(z => context.Rooms.Add(z));


            context.Resorts.Find(1).Rooms.Add(roomList[0]);
            context.Resorts.Find(2).Rooms.Add(roomList[1]);
            context.Resorts.Find(3).Rooms.Add(roomList[2]);


            context.Hotels.Find(1).Rooms.Add(roomList[3]);
            context.Hotels.Find(2).Rooms.Add(roomList[4]);
            context.Hotels.Find(3).Rooms.Add(roomList[5]);

            context.SaveChanges();


            List<HolidayHome> homesList = new List<HolidayHome>();
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 4, numberofBeds = 4, doubleBed = false, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 6, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2});
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 10, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });


            homesList.ForEach(z => context.HolidayHomes.Add(z));



           context.Resorts.Find(1).HolidayHomes.Add(homesList[0]);
            context.Resorts.Find(1).HolidayHomes.Add(homesList[1]);
            context.Resorts.Find(2).HolidayHomes.Add(homesList[2]);

            context.Resorts.Find(2).HolidayHomes.Add(homesList[3]);
            context.Resorts.Find(3).HolidayHomes.Add(homesList[4]);
            context.Resorts.Find(3).HolidayHomes.Add(homesList[5]);
            context.SaveChanges();



           























            base.Seed(context);
        }



    }
}