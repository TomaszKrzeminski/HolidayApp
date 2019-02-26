using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class AddRoomViewModel
    {
        public Room room { get; set; }
        public string name { get; set; }
        public int id { get; set; }
    }
}