using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class SearchModelView
    {

        public SearchModelView()
        {
            holidayhomes = new List<HolidayHome>();
            rooms = new List<Room>();
        }




        public List<HolidayHome> holidayhomes { get; set; }
        public List<Room> rooms { get; set; }

    }


    public class SearchModelViewResortHotel
    {

        public SearchModelViewResortHotel()
        {
            Resorts = new List<Resort>();
            Hotels = new List<Hotel>();
            HotelListOfRooms = new Dictionary<Hotel, List<Room>>();
            ResortListOfHolidayHomes = new Dictionary<Resort, List<HolidayHome>>();
            ResortListOfRooms = new Dictionary<Resort, List<Room>>();

        }




        public List<Resort> Resorts { get; set; }
        public List<Hotel> Hotels { get; set; }
        public Dictionary<Hotel, List<Room>> HotelListOfRooms = new Dictionary<Hotel, List<Room>>();
        public Dictionary<Resort, List<HolidayHome>> ResortListOfHolidayHomes = new Dictionary<Resort, List<HolidayHome>>();
        public Dictionary<Resort, List<Room>> ResortListOfRooms = new Dictionary<Resort, List<Room>>();

    }
}