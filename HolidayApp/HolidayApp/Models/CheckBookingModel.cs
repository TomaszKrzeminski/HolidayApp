using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class CheckBookingModel
    {
        public CheckBookingModel()
        {
            holidayHome = new HolidayHome();
            room = new Room();
        }

        public bool Available { get; set; }
        public DateTime FirstDateAvailable { get; set; }
        public int DaysAvailable { get; set; }
        public HolidayHome holidayHome { get; set; }
        public Room room { get; set; }

    }
}