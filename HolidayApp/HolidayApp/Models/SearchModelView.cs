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
}