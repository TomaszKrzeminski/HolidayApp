using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public enum AddPictureType
    {
        Hoteltype, Resorttype, Roomtype, HolidayHometype, Parkingtype

    }

    public class AddImagesModel
    {

       public AddPictureType type { get; set; }
       public int Id { get; set; }
     public   HttpPostedFileBase file { get; set; }

    }



}