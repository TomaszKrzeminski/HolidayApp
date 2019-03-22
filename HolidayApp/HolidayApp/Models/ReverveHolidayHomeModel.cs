using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public class ReverveHolidayHomeModel
    {
        [Required(ErrorMessage ="Field is Required")]
        [MustBeLaterThanNow(ErrorMessage ="Date must be later than today")]
        public DateTime dateTo  {get;set;}
        [Required(ErrorMessage = "Field is Required")]
        [MustBeLaterThanNow(ErrorMessage = "Date must be later than today")]
        public DateTime dateFrom  {get;set;}
        [Required(ErrorMessage = "Field is Required")]
        public int holidayhomeId { get; set; }


    }

    public class ReverveRoomModel
    {
        [Required(ErrorMessage = "Field is Required")]
        [MustBeLaterThanNow(ErrorMessage = "Date must be later than today")]
        public DateTime dateTo { get; set; }
        [Required(ErrorMessage = "Field is Required")]
        [MustBeLaterThanNow(ErrorMessage = "Date must be later than today")]
        public DateTime dateFrom { get; set; }
        [Required(ErrorMessage = "Field is Required")]
        public int roomId { get; set; }


    }



    public class MustBeLaterThanNowAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if(value==null)
            {
                return false;
            }
            DateTime time = (DateTime)value;
            DateTime now = DateTime.Now;

            if(time<=now)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }

  




}