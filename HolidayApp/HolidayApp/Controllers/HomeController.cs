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


        public ActionResult FiltrRoomAndHolidayHome(string country,string city,Choose choose,int guestnumber=0,int bednumber=0)
        {

            if(string.IsNullOrEmpty(country))
            {
                ModelState.AddModelError("country", "Country is Required");
            }

            if ( string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError("city", "City is Required");
            }


            if (!ModelState.IsValid)
            {
                HolidayViewModel model = new HolidayViewModel();
                model = repository.GetRandomPlaces();

                
                return View("Index",model);
            }



            FiltrFactory factory = new FiltrFactory(repository);
            FiltrRoomHolidayHome filtrclass = factory.CreateObject(choose);
            filtrclass.Country = country;
            filtrclass.City = city;
            filtrclass.choose = choose;
            filtrclass.GuestNumber = guestnumber;
            filtrclass.BedNumber = bednumber;

            filtrclass.Filtr();


            SearchModelView viewmodel = new SearchModelView();
            viewmodel.holidayhomes = filtrclass.HolidayHomes;
            viewmodel.rooms = filtrclass.Rooms;

            return View(viewmodel);
        }





        public ActionResult Index()
        {

            HolidayViewModel model = new HolidayViewModel();
            model = repository.GetRandomPlaces();



            return View(model);
        }

        public ActionResult ShowDetailsHolidayHome(int Id)
        {
            HolidayHome home = repository.GetHolidayHomeById(Id);


            return View(home);
        }

        public ActionResult ShowDetailsParking(int Id)
        {
            Parking parking = repository.GetParkingById(Id);


            return View(parking);
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