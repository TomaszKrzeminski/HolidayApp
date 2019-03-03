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
    [Authorize(Roles = "Owner")]
    public class OwnerController : Controller
    {

        private IHolidaysRepository repository;

        public OwnerController(IHolidaysRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        public ActionResult AddPictures(int Id, int type)
        {

            AddImagesModel model = new AddImagesModel();
            model.Id = Id;
            model.type = (AddPictureType)type;

            return View("AddImages", model);

        }

        [HttpPost]
        public ActionResult FileUpload(AddImagesModel model)
        {
            string text = "";

            if (model.file != null)
            {
                string path = System.IO.Path.Combine(
                                     Server.MapPath("~/Images"),"");
                ObjectFactory factory = new ObjectFactory(repository);
                IAddImage addImage = factory.CreateObject(model.type.ToString());
             text=addImage.AddPathToEntity(model.Id, path);

                if(text=="")
                {
                    return View("AddImagesToMany");
                }


                model.file.SaveAs(path+text);



            }

            if(text.Contains("Hotel"))
            {
                return RedirectToAction("EditHotel",new {id=text[6] });
            }
            else
            {
                return RedirectToAction("EditResort", new { id = text[7] });
            }
          
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

            bool check = repository.AddResort(resort, User.Identity.GetUserId());


            if (check)
            {
                return RedirectToAction("Index", "Owner");
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


        public ActionResult DeleteRoom(int id, int resortId, int hotelId)
        {

            Room room = repository.GetRoomById(id);

            repository.RemoveRoom(id);


            if (hotelId != 0)
            {
                return RedirectToAction("EditHotel", "Owner", new { id = hotelId });
            }
            else
            {
                return RedirectToAction("EditResort", "Owner", new { id = resortId });
            }



        }

        public ActionResult DeleteParking(int id, int resortId, int hotelId)
        {

            Parking parking = repository.GetParkingById(id);

            repository.RemoveParking(id);


            if (hotelId != 0)
            {
                return RedirectToAction("EditHotel", "Owner", new { id = hotelId });
            }
            else
            {
                return RedirectToAction("EditResort", "Owner", new { id = resortId });
            }



        }


        public ActionResult DeleteHolidayHome(int id, int resortId)
        {
            HolidayHome holidayHome = repository.GetHolidayHomeById(id);
            repository.RemoveHolidayHome(id);


            return RedirectToAction("EditResort", "Owner", new { id = resortId });



        }



        public ActionResult RemoveResort(int id)
        {


            repository.RemoveResort(id);

            return RedirectToAction("Index");



        }

        public ActionResult RemoveHotel(int id)
        {


            repository.RemoveHotel(id);

            return RedirectToAction("Index");



        }






        public ActionResult AddRoom(int id, string name)
        {

            if (name == "Hotel")
            {
                return View("AddRoomToHotel", new AddRoomViewModel() { name = name, id = id });
            }
            else if (name == "Resort")
            {
                return View("AddRoomToResort", new AddRoomViewModel() { name = name, id = id });
            }


            return View("Error");

        }

        [HttpPost]
        public ActionResult AddRoom(Room room, string name, int id)
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



        public ActionResult AddHolidayHome(int id, string name)
        {


            return View("AddHolidayHomeToResort", new AddHolidayHomeViewModel() { name = name, id = id });

        }

        [HttpPost]
        public ActionResult AddHolidayHome(HolidayHome holidayhome, string name, int id)
        {



            repository.AddHolidayHomeToResort(holidayhome, id);
            return RedirectToAction("EditResort", new { id = id });





        }







        public ActionResult AddParking(int id, string name)
        {

            if (name == "Hotel")
            {
                return View("AddParkingToHotel", new AddParkingViewModel() { name = name, id = id });
            }
            else if (name == "Resort")
            {
                return View("AddParkingToResort", new AddParkingViewModel() { name = name, id = id });
            }


            return View("Error");

        }

        [HttpPost]
        public ActionResult AddParking(Parking parking, string name, int id)
        {

            if (name == "Hotel")
            {
                repository.AddParkingToHotel(parking, id);
                return RedirectToAction("EditHotel", new { id = id });
            }
            else if (name == "Resort")
            {
                repository.AddParkingToResort(parking, id);
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