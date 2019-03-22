using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HolidayApp.Entities;

namespace HolidayApp.Models
{
    public class BookViewModel
    {
        public HolidayHome holidayhome { get; set; }
        public List<string> list { get; set; }
    }

    public class BookRoomViewModel
    {
        public Room room { get; set; }
        public List<string> list { get; set; }
    }
}