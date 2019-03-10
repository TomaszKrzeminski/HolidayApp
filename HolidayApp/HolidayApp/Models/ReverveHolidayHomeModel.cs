using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class ReverveHolidayHomeModel
    {
        public DateTime dateTo  {get;set;}
        public DateTime dateFrom  {get;set;}
        public int holidayhotelId { get; set; }


    }
}