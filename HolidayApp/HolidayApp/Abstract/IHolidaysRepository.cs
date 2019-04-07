using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Abstract
{
    public interface IHolidaysRepository
    {

        HolidayViewModel GetRandomPlaces();
        HolidayViewModel GetModelByUser(string UserId);
        bool AddResort(Resort resort, string UserId);
        bool AddHotel(Hotel hotel, string UserId);
        Hotel GetHotelByID(int id);
        bool ChangeHotel(Hotel hotel);
        Resort GetResortByID(int id);
        bool ChangeResort(Resort resort);
        bool RemoveRoom(int id);
        Room GetRoomById(int id);
        bool AddRoomToResort(Room room, int id);
        bool AddRoomToHotel(Room room, int id);
        Parking GetParkingById(int id);
        bool RemoveParking(int id);
        bool AddParkingToHotel(Parking parking, int id);
        bool AddParkingToResort(Parking parking, int id);
        HolidayHome GetHolidayHomeById(int id);
        bool RemoveHolidayHome(int id);
        bool AddHolidayHomeToResort(HolidayHome holidayhome, int id);
        bool RemoveHotel(int id);
        bool RemoveResort(int id);

        string AddPictureResort(int Id, string Path);
        string AddPictureHotel(int Id, string Path);
        string AddPictureRoom(int Id, string Path);
        string AddPictureParking(int Id, string Path);
        string AddPictureHolidayHome(int Id, string Path);

        Image GetImageByIdHotel(int Id, int TypeId);
        Image GetImageByIdResort(int Id, int TypeId);
        Image GetImageByIdRoom(int Id, int TypeId);
        Image GetImageByIdParking(int Id, int TypeId);
        Image GetImageByIdHolidayHome(int Id, int TypeId);

        List<Image> GetAllImagesHotel(int Id);
        List<Image> GetAllImagesResort(int Id);
        List<Image> GetAllImagesRoom(int Id);
        List<Image> GetAllImagesParking(int Id);
        List<Image> GetAllImagesHolidayHome(int Id);

        List<HolidayHome> GetListHHByCountryAndCity(string Country,string City);
        List<Room> GetListRByCountryAndCity(string Country,string City);

     
        CheckBookingModel bookholidayhome(int Id, DateTime from, DateTime to);
        CheckBookingModel bookroom(int Id, DateTime from, DateTime to);
        List<DateTime> GetDaysBookedHolidayHome(int Id);
        List<DateTime> GetDaysBookedRoom(int Id);

        List<Resort> GetResortsByCountryAndCity(string Country, string City);
        List<Hotel> GetHotelsByCountryAndCity(string Country, string City);

        bool AddComment(Resort resort,Hotel hotel,ApplicationUser user,string text);
        ApplicationUser GetUserById(string Id);
        List<Comment> GetCommentsResort(int Id);
        List<Comment> GetCommentsHotel(int Id);
        bool RemoveComment(int Id);



    }
}