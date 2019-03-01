using HolidayApp.Abstract;
using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayApp.Controllers
{
    public class HomeController : Controller
    {

        private IHolidaysRepository repository;

        public HomeController(IHolidaysRepository  repoparam)
        {

            repository = repoparam;

        }







        public ActionResult Index()
        {

            HolidayViewModel model = new HolidayViewModel();
            model = repository.GetRandomPlaces();



            return View(model);
        }

        public ActionResult ShowDetailsRoom(int Id)
        {
            Room room = repository.GetRoomById(Id);


            return View(room);
        }
     


        public ActionResult ShowDetailsHotel(int Id)
        {
             Hotel hotel= repository.GetHotelByID(Id);



            return View(hotel);
        }
        public ActionResult ShowDetailsResort(int Id)
        {

            Resort resort = repository.GetResortByID(Id);




            return View(resort);
        }

        public ActionResult GetDetails()
        {



            return PartialView();
        }


        public ActionResult SortElementsinDetails()
        {



            return PartialView();
        }
   public ActionResult  SortElements()
        {


            return PartialView();
        }



        public ActionResult ShowResults()
        {




            return PartialView();
        }

    }
}