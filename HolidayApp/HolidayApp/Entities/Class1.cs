using HolidayApp.Abstract;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Entities
{


    public class ReserveObject
    {
        public int ReserveObjectId { get; set; }
      
        public DateTime bookingFrom { get; set; }
        public  DateTime bookingToo { get; set; }
      
        public int totalNights { get; set; }

        public virtual Room Room { get; set; }

        public virtual HolidayHome HolidayHome { get; set; }

    }











    public interface IAddImage
    {
        string AddPathToEntity(int Id, string Path);
        Image GetImageFromDb(int Id, int TypeId);
        List<Image> GetImages(int Id);
    }






    public class Image
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }


        public virtual Resort Resort { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual Room Room { get; set; }

        public virtual HolidayHome HolidayHome { get; set; }

        public virtual Parking Parking { get; set; }

       
    }


    public class Comment
    {

        public int CommentId { get; set; }
        public string Text { get; set; }


        public virtual Hotel Hotel { get; set; }
        public virtual Resort Resort { get; set; }
        public virtual ApplicationUser User { get; set; }




    }



    public class Resort : IAddImage
    {

        IHolidaysRepository repository;

       
        public Resort()
        {
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            HolidayHomes = new HashSet<HolidayHome>();
            Comments = new HashSet<Comment>();
        }


        public Resort(IHolidaysRepository  repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            HolidayHomes = new HashSet<HolidayHome>();
            Comments = new HashSet<Comment>();
        }

        public int ResortId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }

        public string ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }


        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<HolidayHome> HolidayHomes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public string AddPathToEntity(int Id, string Path)
        {
           return repository.AddPictureResort(Id, Path);
        }

        public Image GetImageFromDb(int Id, int TypeId)
        {
            return repository.GetImageByIdResort(Id, TypeId);
        }

        public List<Image> GetImages(int Id)
        {
            return repository.GetAllImagesResort(Id);
        }
    }



    public class Hotel : IAddImage
    {
        IHolidaysRepository repository;
        public Hotel(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            Comments = new HashSet<Comment>();

        }

        public Hotel()
        {
            Images = new HashSet<Image>();
            Rooms = new HashSet<Room>();
            Parkings = new HashSet<Parking>();
            Comments = new HashSet<Comment>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureHotel(Id, Path);
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int TelephoneNumber { get; set; }

        public Image GetImageFromDb(int Id, int TypeId)
        {
            return repository.GetImageByIdHotel(Id, TypeId);
        }

        public List<Image> GetImages(int Id)
        {
            return repository.GetAllImagesHotel(Id);
        }

        public  string ApplicationUserID { get; set; }
        public Models.ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Parking> Parkings { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }



    public class Room : IAddImage
    {
        IHolidaysRepository repository;
        public Room(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
            reserveTimes = new HashSet<ReserveObject>();
        }
        public Room()
        {
            reserveTimes = new HashSet<ReserveObject>();
            Images = new HashSet<Image>();
        }
        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureRoom(Id, Path);
        }

        public int RoomId { get; set; }

        public decimal Price { get; set; }

        public int numberofGuests { get; set; }

        public int numberofBeds { get; set; }

        public bool doubleBed { get; set; }
                
        public bool petsAllowed { get; set; }
        
        public bool Kitchen { get; set; }

        public bool Toilet { get; set; }

        public int  numberofTelevisions{get;set;}

        public List<Image> GetImages(int Id)
        {
            return repository.GetAllImagesRoom(Id);
        }

        public Image GetImageFromDb(int Id, int TypeId)
        {
            return repository.GetImageByIdRoom(Id, TypeId);
        }
        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }


        public virtual ICollection<ReserveObject> reserveTimes { get; set; }


    }



    public class HolidayHome : IAddImage
    {
        IHolidaysRepository repository;
        public HolidayHome(IHolidaysRepository repoparam)
        {
            reserveTimes = new HashSet<ReserveObject>();
            repository = repoparam;
            Images = new HashSet<Image>();
        }
        public HolidayHome()
        {
            reserveTimes = new HashSet<ReserveObject>();
            Images = new HashSet<Image>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureHolidayHome(Id, Path);
        }
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


        public Image GetImageFromDb(int Id, int TypeId)
        {
            return repository.GetImageByIdHolidayHome(Id, TypeId);
        }



        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        public List<Image> GetImages(int Id)
        {
            return repository.GetAllImagesHolidayHome(Id);
        }

        public virtual ICollection<ReserveObject> reserveTimes { get; set; }
    }



    public class Parking : IAddImage
    {
        IHolidaysRepository repository;
        public Parking(IHolidaysRepository repoparam)
        {
            repository = repoparam;
            Images = new HashSet<Image>();
        }
        public Parking()
        {
            Images = new HashSet<Image>();
        }

        public string AddPathToEntity(int Id, string Path)
        {
            return repository.AddPictureParking(Id, Path);
        }
        public int ParkingId { get; set; }

        public int parkingPlaces { get; set; }

        public decimal pricePerDay { get; set; }

        public bool Guarded { get; set; }

        public List<Image> GetImages(int Id)
        {
            return repository.GetAllImagesParking(Id);
        }

        public virtual ICollection<Image> Images { get; set; }
        //public int ResortId { get; set; }
        public virtual Resort Resort { get; set; }

        //public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public Image GetImageFromDb(int Id, int TypeId)
        {
          return  repository.GetImageByIdRoom(Id, TypeId);
        }

    }









}