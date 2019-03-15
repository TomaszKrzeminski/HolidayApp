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
    public class ClientController : Controller
    {


        private IHolidaysRepository repository;

        public ClientController(IHolidaysRepository repoparam)
        {

            repository = repoparam;

        }



        public ActionResult ShowWhenBooked(int Id=0)
        {
            return PartialView();
        }


        public ActionResult ReserveRoom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ReserveHolidayHome(ReverveHolidayHomeModel model)
        {

           if(model.dateTo<=model.dateFrom)
            {
                ModelState.AddModelError("dateTo", "Date should be later than above");
            }

            if(model.dateFrom==null)
            {
                ModelState.AddModelError("dateFrom", "Pole nie moze być puste");
            }


            if(ModelState.IsValid)
            {
                //repository.BookHolidayHome(model.holidayhomeId, model.dateFrom, model.dateTo);

                CheckBookingModel modelbook = repository.bookholidayhome(model.holidayhomeId, model.dateFrom, model.dateTo);
                ViewBag.checkbookingmodel = modelbook;

 return RedirectToAction("ShowDetailsHolidayHome","Home",new {Id=model.holidayhomeId });
            }
            else
            {
                HolidayHome home = repository.GetHolidayHomeById(model.holidayhomeId);
                return View("~/Views/Home/ShowDetailsHolidayHome.cshtml", home);
               


            }



           
        }




    }
}