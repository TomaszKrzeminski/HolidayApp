using HolidayApp.Abstract;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayApp.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private IHolidaysRepository repository;

        public AdminController(IHolidaysRepository repoparam)
        {

            repository = repoparam;

        }



        public ActionResult RemoveComment( int id)
        {

            bool isTrue = repository.RemoveComment(id);



            if(isTrue)
            {
               



                return RedirectToAction("Index","Home",null);
            }
            else
            {
               return View("RemoveCommentError");
            }
           
        }



        public ActionResult Index()
        {
            return View();
        }
    }
}