using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class HolidayViewModel
    {

        public HolidayViewModel()
        {
            ResortList = new List<Resort>();
            HotelList = new List<Hotel>();
            RoomList = new List<Room>();
        }


        public int ResortCount { get; set; }
        public int HotelCount { get; set; }
        public int RoomCount { get; set; }

        

        public List<Resort> ResortList { get; set; }
        public List<Hotel> HotelList { get; set; }
        public List<Room> RoomList { get; set; }
        public string UserId { get; set; }


    }
}