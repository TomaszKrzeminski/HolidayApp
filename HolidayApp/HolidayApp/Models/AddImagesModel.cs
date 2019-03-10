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


    public enum Angle
    {
       rotate0, rotate90, rotate180
    }


    public class EditImageModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public AddPictureType type { get; set; }
        public string imagePath { get; set; }

    }
   

    public class AddImagesModel
    {

        public AddPictureType type { get; set; }
        public int Id { get; set; }
        public int TypeId { get; set; }
        public HttpPostedFileBase file { get; set; }
        public int rotate { get; set; }
        public Angle angle { get; set; }
        

    }



}