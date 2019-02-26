using HolidayApp.Abstract;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using HolidayApp.Entities;

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


        public ActionResult AddResort()
        {
            Resort newResort = new Resort();
            return View(newResort);
        }

         [HttpPost]
        public ActionResult AddResort(Resort resort)
        {

          bool check= repository.AddResort(resort, User.Identity.GetUserId());


            if(check)
            {
return   RedirectToAction("Index", "Owner");
            }
                else
            {
                return View("Error", "Error adding Resort");
            }

         
        }




        public ActionResult AddHotel()
        {
            Hotel hotel = new Hotel();
            return View(hotel);
        }

        [HttpPost]
        public ActionResult AddHotel(Hotel hotel)
        {
            bool check = repository.AddHotel(hotel, User.Identity.GetUserId());


            if (check)
            {
                return RedirectToAction("Index", "Owner");
            }
            else
            {
                return View("Error", "Error adding Resort");
            }
        }

        public ActionResult EditResort(int Id)
        {

            Resort resort = repository.GetResortByID(Id);


            return View(resort);
        }

        [HttpPost]
        public ActionResult EditResort(Resort resort)
        {

            repository.ChangeResort(resort);


            return RedirectToAction("Index", "Owner");
        }


        public ActionResult DeleteRoom (int id)
        {

            Room room = repository.GetRoomById(id);
            
            repository.RemoveRoom(id);


            if (room.Hotel != null)
            {
                return RedirectToAction("EditHotel", "Owner", new {id=room.Hotel.HotelId });
            }
            else
            {
                return RedirectToAction("EditResort", "Owner",new { id = room.Resort.ResortId });
            }
            


        }


        public ActionResult AddRoom(int id,string name)
        {

            if(name=="Hotel")
            {
                return View("AddRoomToHotel",new AddRoomViewModel() {name=name,id=id });
            }
            else if(name=="Resort")
            {
                return View("AddRoomToResort",new AddRoomViewModel() { name = name, id = id });
            }


            return View("Error");

        }

        [HttpPost]
        public ActionResult AddRoom(Room room,string name,int id)
        {

            if (name == "Hotel")
            {
                repository.AddRoomToHotel(room, id);
                return RedirectToAction("EditHotel", new { id = id });
            }
            else if (name == "Resort")
            {
                repository.AddRoomToResort(room, id);
                return RedirectToAction("EditResort", new { id = id });
            }


            return View("Error");

        }



        public ActionResult EditHotel(int Id)
        {

            Hotel hotel = repository.GetHotelByID(Id);


            return View(hotel);
        }

        [HttpPost]
        public ActionResult EditHotel(Hotel hotel)
        {

            repository.ChangeHotel(hotel);


            return RedirectToAction("Index", "Owner");
        }


    }
}