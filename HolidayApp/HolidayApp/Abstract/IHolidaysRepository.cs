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
        bool AddResort(Resort resort,string UserId);
        bool AddHotel(Hotel hotel,string UserId);
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





        //bool AddRoom(Resort resort, Room room);
        //bool AddRoom(Hotel hotel, Room room);
        //bool AddParking(Resort resort, Parking parking);
        //bool AddParking(Hotel hotel, Parking parking);
        //bool AddHolidayHome(Resort resort, HolidayHome holidayhome);




    }
}