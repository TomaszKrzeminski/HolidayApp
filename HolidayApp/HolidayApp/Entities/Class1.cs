using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Entities
{
    public class Resort
    {

        public Resort()
        {
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            HolidayHomes = new HashSet<HolidayHome>();
        }

        public int ResortId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }

        public int ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<HolidayHome> HolidayHomes { get; set; }

    }



    public class Hotel
    {

        public Hotel()
        {
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();

        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }


        public int ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }

    }



    public class Room
    {

        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public int numberofGuests { get; set; }

        public int numberofBeds { get; set; }

        public bool doubleBed { get; set; }
                
        public bool petsAllowed { get; set; }
        
        public bool Kitchen { get; set; }

        public bool Toilet { get; set; }

        public int  numberofTelevisions{get;set;}



        //public int ResortId { get; set; }
        public Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }



    public class HolidayHome
    {

        public int HolidayHomeId { get; set; }

        public decimal Price { get; set; }

        public int numberofGuests { get; set; }

        public int numberofBeds { get; set; }

        public bool doubleBed { get; set; }

        public bool petsAllowed { get; set; }

        public bool Kitchen { get; set; }

        public bool Toilet { get; set; }

        public int numberofTelevisions { get; set; }

        public int numberofFloors { get; set; }







        //public int ResortId { get; set; }
        public Resort Resort { get; set; }

        

    }



    public class Parking
    {
        public int ParkingId { get; set; }

        public int parkingPlaces { get; set; }

        public decimal pricePerDay { get; set; }

        public bool Guarded { get; set; }


        //public int ResortId { get; set; }
        public Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public Hotel Hotel { get; set; }


    }









}