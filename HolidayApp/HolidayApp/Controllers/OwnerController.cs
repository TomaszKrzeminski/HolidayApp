using HolidayApp.Abstract;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace HolidayApp.Controllers
{
    [Authorize]
    [Authorize(Roles ="Owner")]
    public class OwnerController : Controller
    {

        private IHolidaysRepository repository;

        public OwnerController(IHolidaysRepository repositoryParam)
        {
            repository = repositoryParam;
        }



        // GET: Owner
        public ActionResult Index()
        {
            HolidayViewModel model = new HolidayViewModel();
            model = repository.GetModelByUser(User.Identity.GetUserId());


            return View(model);
        }
    }
}