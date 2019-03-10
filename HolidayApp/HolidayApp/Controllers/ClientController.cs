using HolidayApp.Abstract;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayApp.Controllers
{
    public class ClientController : Controller
    {


        private IHolidaysRepository repository;

        public ClientController(IHolidaysRepository repoparam)
        {

            repository = repoparam;

        }



        public ActionResult ReserveRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReserveHolidayHome(ReverveHolidayHomeModel model)
        {
            return View();
        }




    }
}