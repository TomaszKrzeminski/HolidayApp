using HolidayApp.Abstract;
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

        
        public ActionResult  SortElements()
        {


            return PartialView();
        }



        public ActionResult ShowResults()
        {




            return PartialView();
        }

        public ActionResult ShowDetails()
        {




            return View();
        }

        public ActionResult GetDetails()
        {



            return PartialView();
        }


        public ActionResult SortElementsinDetails()
        {



            return PartialView();
        }


    }
}