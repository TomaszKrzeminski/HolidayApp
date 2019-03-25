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


        public ActionResult FiltrRoomAndHolidayHome(string country,string city,Choose choose,int guestnumber=0,int bednumber=0,DateTime? bookfrom=null,DateTime? bookto=null)
        {

            if(string.IsNullOrEmpty(country))
            {
                ModelState.AddModelError("country", "Country is Required");
            }

            if ( string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError("city", "City is Required");
            }


            if(bookfrom>bookto)
            {
                ModelState.AddModelError("bookfrom", "Book From is Later than Book To");
            }

            if (bookfrom == bookto&&bookto!=null)
            {
                ModelState.AddModelError("bookfrom", "Book From is equal Book To");
            }


            if(bookfrom<=DateTime.Now)
            {
                ModelState.AddModelError("bookfrom", "Book From should be later than today");
            }

            if (bookto<= DateTime.Now)
            {
                ModelState.AddModelError("bookto", "Book to should be later than today");
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
            filtrclass.BookFrom = bookfrom==null?DateTime.MinValue:(DateTime)bookfrom ;
            filtrclass.BookTo =bookto==null?DateTime.MinValue:(DateTime)bookto;


            filtrclass.Filtr();


            SearchModelView viewmodel = new SearchModelView();
            viewmodel.holidayhomes = filtrclass.HolidayHomes;
            viewmodel.rooms = filtrclass.Rooms;

            return View(viewmodel);
        }


        public ActionResult FiltrRoomAndHolidayHomeSecond(string country, string city, Choose choose, int guestnumber = 0, int bednumber = 0, DateTime? bookfrom = null, DateTime? bookto = null,List<HolidayHome> holidayhomes=null,List<Room> rooms=null)
        {

            List<Room> r = rooms;

            if (string.IsNullOrEmpty(country))
            {
                ModelState.AddModelError("country", "Country is Required");
            }

            if (string.IsNullOrEmpty(city))
            {
                ModelState.AddModelError("city", "City is Required");
            }


            if (bookfrom > bookto)
            {
                ModelState.AddModelError("bookfrom", "Book From is Later than Book To");
            }

            if (bookfrom == bookto && bookto != null)
            {
                ModelState.AddModelError("bookfrom", "Book From is equal Book To");
            }


            if (bookfrom <= DateTime.Now)
            {
                ModelState.AddModelError("bookfrom", "Book From should be later than today");
            }

            if (bookto <= DateTime.Now)
            {
                ModelState.AddModelError("bookto", "Book to should be later than today");
            }

            if (!ModelState.IsValid)
            {
                SearchModelView viewModel = new SearchModelView();
                if(holidayhomes==null)
                {
                    holidayhomes = new List<HolidayHome>();
                }
                if(rooms==null)
                {
                    rooms = new List<Room>();
                }
                viewModel.holidayhomes = holidayhomes;
                viewModel.rooms = rooms;


                return View("FiltrRoomAndHolidayHome", viewModel);
            }



            FiltrFactory factory = new FiltrFactory(repository);
            FiltrRoomHolidayHome filtrclass = factory.CreateObject(choose);
            filtrclass.Country = country;
            filtrclass.City = city;
            filtrclass.choose = choose;
            filtrclass.GuestNumber = guestnumber;
            filtrclass.BedNumber = bednumber;
            filtrclass.BookFrom = bookfrom == null ? DateTime.MinValue : (DateTime)bookfrom;
            filtrclass.BookTo = bookto == null ? DateTime.MinValue : (DateTime)bookto;


            filtrclass.Filtr();


            SearchModelView viewmodel = new SearchModelView();
            viewmodel.holidayhomes = filtrclass.HolidayHomes;
            viewmodel.rooms = filtrclass.Rooms;

            return View("FiltrRoomAndHolidayHome", viewmodel);
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