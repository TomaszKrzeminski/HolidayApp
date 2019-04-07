using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Moq;
using HolidayApp.Abstract;
using HolidayApp.Models;
using HolidayApp.Entities;


using HolidayApp.Controllers;

namespace AppHoliday.UnitTests
{
    class AppHolidayTests
    {












        [Test]
        public void when_calling_Index_the_result_is_model()
        {

            List<Resort> resortList = new List<Resort>();
            resortList.Add(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            resortList.Add(new Resort() { Name = "Resort Sopot", City = "Sopot", Country = "Poland", TelephoneNumber = 794219755 });
            resortList.Add(new Resort() { Name = "Resort Gdańsk", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });









            List<Hotel> hotelList = new List<Hotel>();
            hotelList.Add(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            hotelList.Add(new Hotel() { Name = "Hotel Warszawa", City = "Warszawa", Country = "Poland", TelephoneNumber = 777888555 });
            hotelList.Add(new Hotel() { Name = "Hotel Katowice", City = "Katowice", Country = "Poland", TelephoneNumber = 777888444 });


            List<Room> roomList = new List<Room>();
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });



            List<Room> roomList2 = new List<Room>();
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 400, numberofGuests = 4, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 400, numberofGuests = 4, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 800, numberofGuests = 8, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            roomList.Add(new Room() { Price = 800, numberofGuests = 8, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });


            foreach (var resort in resortList)
            {
                foreach (var room in roomList)
                {
                    resort.Rooms.Add(room);
                }
            }



            foreach (var hotel in hotelList)
            {
                foreach (var room in roomList2)
                {
                    hotel.Rooms.Add(room);
                }
            }


            HolidayViewModel modelrepo=new HolidayViewModel() { HotelList = hotelList, RoomList = roomList, ResortList = resortList, HotelCount = hotelList.Count, ResortCount = resortList.Count, RoomCount = roomList.Count }; 

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetRandomPlaces()).Returns(modelrepo);



            HomeController controller = new HomeController(mock.Object);



            HolidayViewModel model =(HolidayViewModel)((ViewResult)controller.Index()).Model;


            Assert.AreEqual(model, modelrepo);


        }

        [Test]
        public void when_calling_Index_the_result_is_index_view()
        {

           


            HolidayViewModel modelrepo = new HolidayViewModel() ;

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetRandomPlaces()).Returns(modelrepo);



            HomeController controller = new HomeController(mock.Object);



            ViewResult model =(ViewResult)controller.Index();


            Assert.AreEqual(model.ViewName, "Index");


        }

      
           [Test]
        public void when_calling_ShowAvailableRoomsHolidayHome_returns_SearchModelView()
        {
            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            
            HomeController controller = new HomeController(mock.Object);


            List<Room> roomList = new List<Room>();
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });

          
            List<HolidayHome> homesList = new List<HolidayHome>();
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 4, numberofBeds = 4, doubleBed = false, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 6, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 10, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });



            SearchModelView model = new SearchModelView();
            model.holidayhomes = homesList;
            model.rooms = roomList;



            SearchModelView result =(SearchModelView)((ViewResult)controller.ShowAvailableRoomsHolidayHomes(roomList, homesList)).Model;

            Assert.AreEqual(result.holidayhomes, model.holidayhomes);
            Assert.AreEqual(result.rooms, model.rooms);






        }

        [Test]
        public void when_calling_GetComments_returns_CommentsView_Hotel()
        {

            int Id = 1;

            List<Comment> commentList = new List<Comment>();

            for (int i = 0; i < 5; i++)
            {
                Comment comment = new Comment();
                comment.CommentId = i;
                comment.Text = "CommentH"+i;
                comment.User = new ApplicationUser();
                commentList.Add(comment);
            }

            CommentsView model = new CommentsView();
            model.Comments = commentList;

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetCommentsHotel(It.IsAny<int>())).Returns(commentList);
            mock.Setup(m => m.GetCommentsResort(It.IsAny<int>())).Returns(commentList);
            HomeController controller = new HomeController(mock.Object);


            CommentsView result = (CommentsView)((PartialViewResult)controller.GetComments("Hotel", Id)).ViewData.Model;


            Assert.AreEqual(result.Comments, model.Comments);


        }

        [Test]
        public void when_calling_GetComments_returns_CommentsView_Resort()
        {


            int Id = 1;

            List<Comment> commentList = new List<Comment>();

            for (int i = 0; i < 5; i++)
            {
                Comment comment = new Comment();
                comment.CommentId = i;
                comment.Text = "CommentR" + i;
                comment.User = new ApplicationUser();
                commentList.Add(comment);
            }

            CommentsView model = new CommentsView();
            model.Comments = commentList;

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetCommentsHotel(It.IsAny<int>())).Returns(commentList);
            mock.Setup(m => m.GetCommentsResort(It.IsAny<int>())).Returns(commentList);
            HomeController controller = new HomeController(mock.Object);

            CommentsView result =(CommentsView)((PartialViewResult)controller.GetComments("Resort", Id)).ViewData.Model;


            Assert.AreEqual(result.Comments, model.Comments);
          


        }


        [Test]
        public void when_calling_AddComment_returns_view_Error()
        {





        }

        [Test]
        public void when_calling_AddComment_returns_view_FiltrResortHotel()
        {





        }


        [Test]
        public void when_calling_AddComment_returns_view_FiltrResortHotel()
        {





        }


    }
}
