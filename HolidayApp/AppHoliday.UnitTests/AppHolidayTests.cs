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


            HolidayViewModel modelrepo = new HolidayViewModel() { HotelList = hotelList, RoomList = roomList, ResortList = resortList, HotelCount = hotelList.Count, ResortCount = resortList.Count, RoomCount = roomList.Count };

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetRandomPlaces()).Returns(modelrepo);



            HomeController controller = new HomeController(mock.Object);



            HolidayViewModel model = (HolidayViewModel)((ViewResult)controller.Index()).Model;


            Assert.AreEqual(model, modelrepo);


        }

        [Test]
        public void when_calling_Index_the_result_is_index_view()
        {




            HolidayViewModel modelrepo = new HolidayViewModel();

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(m => m.GetRandomPlaces()).Returns(modelrepo);



            HomeController controller = new HomeController(mock.Object);



            ViewResult model = (ViewResult)controller.Index();


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



            SearchModelView result = (SearchModelView)((ViewResult)controller.ShowAvailableRoomsHolidayHomes(roomList, homesList)).Model;

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
                comment.Text = "CommentH" + i;
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

            CommentsView result = (CommentsView)((PartialViewResult)controller.GetComments("Resort", Id)).ViewData.Model;


            Assert.AreEqual(result.Comments, model.Comments);



        }


        [Test]
        public void when_calling_AddComment_returns_view_Error()
        {

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(new ApplicationUser() { UserName = "User1", Id = "aaa-bbb-ccc" });

            mock.Setup(x => x.GetHotelByID(It.IsAny<int>())).Returns(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            mock.Setup(x => x.GetResortByID(It.IsAny<int>())).Returns(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            mock.Setup(x => x.AddComment(null, It.IsAny<Hotel>(), It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(false);
            HomeController controller = new HomeController(mock.Object, () => "aaa-bbb-ddd");



            ViewResult result = ((ViewResult)controller.AddComment("", ""));


            Assert.AreEqual(result.ViewName, "Error");








        }

        [Test]
        public void when_calling_AddComment_returns_view_FiltrResortHotel()
        {

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(new ApplicationUser() { UserName = "User1", Id = "aaa-bbb-ccc" });

            List<Hotel> listHotel = new List<Hotel>() { new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 } };

            Mock<FiltrResortHotel> mockAbstract = new Mock<FiltrResortHotel>();
            mockAbstract.Setup(x => x.Hotels).Returns(listHotel);

            mock.Setup(x => x.GetHotelByID(It.IsAny<int>())).Returns(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            mock.Setup(x => x.GetResortByID(It.IsAny<int>())).Returns(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            mock.Setup(x => x.AddComment(null, It.IsAny<Hotel>(), It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(true);
            HomeController controller = new HomeController(mock.Object, () => "aaa-bbb-ddd", mockAbstract.Object);



            ViewResult result = ((ViewResult)controller.AddComment("Poland", "Kraków", 1, 2, new DateTime(2019, 8, 25), new DateTime(2019, 8, 25), "Hotel", 1, "text"));


            Assert.AreEqual(result.ViewName, "FiltrResortHotel");

            SearchModelViewResortHotel model = (SearchModelViewResortHotel)result.Model;
            Assert.AreEqual(model.Hotels.First().City, "Kraków");





        }


        [Test]
        public void when_adding_model_error_FiltrRoomAndHolidayHome_redirects()
        {

            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetRandomPlaces()).Returns(new HolidayViewModel());

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)controller.FiltrRoomAndHolidayHome("", "");

            Assert.AreEqual(result.ViewName, "Index");



        }


        [Test]
        public void when_there_is_no_model_error_FiltrRoomAndHolidayHome_returns_view_index()
        {
            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetRandomPlaces()).Returns(new HolidayViewModel());

            HomeController controller = new HomeController(mock.Object);

            RedirectToRouteResult result = (RedirectToRouteResult)controller.FiltrRoomAndHolidayHome("Poland", "Kraków");

            var data = result.RouteValues;
            string s = data["action"].ToString();


            Assert.AreEqual(data["action"].ToString(), "FiltrResortHotel");




        }



        [Test]
        public void when_there_is_no_model_error_FiltrResortHotel_returns_view_index()
        {


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(new ApplicationUser() { UserName = "User1", Id = "aaa-bbb-ccc" });

            List<Hotel> listHotel = new List<Hotel>() { new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 } };

            Mock<FiltrResortHotel> mockAbstract = new Mock<FiltrResortHotel>();
            mockAbstract.Setup(x => x.Hotels).Returns(listHotel);

            //mock.Setup(x => x.GetHotelByID(It.IsAny<int>())).Returns(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            //mock.Setup(x => x.GetResortByID(It.IsAny<int>())).Returns(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            //mock.Setup(x => x.AddComment(null, It.IsAny<Hotel>(), It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(true);
            HomeController controller = new HomeController(mock.Object, () => "aaa-bbb-ddd", mockAbstract.Object);



            ViewResult result = ((ViewResult)controller.FiltrResortHotel("Poland", "Kraków", 1, 2, new DateTime(2019, 8, 25), new DateTime(2019, 8, 25)));


            Assert.AreEqual(result.ViewName, "FiltrResortHotel");

            SearchModelViewResortHotel model = (SearchModelViewResortHotel)result.Model;
            Assert.AreEqual(model.Hotels.First().City, "Kraków");



        }



        [Test]
        public void when_room_list_is_null_FiltrRoomAndHolidayHomeSecond_returns_model_room_list_count_0()
        {


            //List<Room> roomList = new List<Room>();
            //roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            //roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            //roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            //roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            //roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            //roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });




            List<HolidayHome> homesList = new List<HolidayHome>();
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 4, numberofBeds = 4, doubleBed = false, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 400, numberofGuests = 6, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });
            homesList.Add(new HolidayHome() { Price = 800, numberofGuests = 10, numberofBeds = 10, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });









            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(new ApplicationUser() { UserName = "User1", Id = "aaa-bbb-ccc" });

            List<Hotel> listHotel = new List<Hotel>() { new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 } };

            Mock<FiltrResortHotel> mockAbstract = new Mock<FiltrResortHotel>();
            mockAbstract.Setup(x => x.Hotels).Returns(listHotel);

            //mock.Setup(x => x.GetHotelByID(It.IsAny<int>())).Returns(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            //mock.Setup(x => x.GetResortByID(It.IsAny<int>())).Returns(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            //mock.Setup(x => x.AddComment(null, It.IsAny<Hotel>(), It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(true);
            HomeController controller = new HomeController(mock.Object, () => "aaa-bbb-ddd", mockAbstract.Object);



            ViewResult result = ((ViewResult)controller.FiltrRoomAndHolidayHomeSecond("Poland", "Kraków", Choose.HolidayHome, 1, 2, new DateTime(2019, 8, 25), new DateTime(2019, 8, 25), homesList));

            SearchModelView viewModel = (SearchModelView)result.Model;


            Assert.AreEqual(viewModel.holidayhomes.Count, 6);
            Assert.AreEqual(viewModel.rooms.Count, 0);




        }


        [Test]
        public void when_model_is_valid_FiltrRoomAndHolidayHomeSecond_returns_model_room_and_holidayhomes_count_more_than_0()
        {

            List<Room> roomList = new List<Room>();
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 2, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 1 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 3, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });
            roomList.Add(new Room() { Price = 300, numberofGuests = 3, numberofBeds = 2, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2 });




            List<HolidayHome> homesList = new List<HolidayHome>();
            homesList.Add(new HolidayHome() { HolidayHomeId = 1, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 7, Price = 200, numberofGuests = 1, numberofBeds = 2, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 8, Price = 300, numberofGuests = 1, numberofBeds = 2, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 2, Price = 200, numberofGuests = 2, numberofBeds = 1, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 1, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 3, Price = 400, numberofGuests = 4, numberofBeds = 4, doubleBed = false, petsAllowed = true, Toilet = false, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 4, Price = 400, numberofGuests = 6, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 2, numberofFloors = 1 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 5, Price = 800, numberofGuests = 10, numberofBeds = 5, doubleBed = true, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });
            homesList.Add(new HolidayHome() { HolidayHomeId = 6, Price = 800, numberofGuests = 10, numberofBeds = 10, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = true, numberofTelevisions = 3, numberofFloors = 2 });





            List<Resort> resortList = new List<Resort>();
            resortList.Add(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            resortList.Add(new Resort() { Name = "Resort Sopot", City = "Sopot", Country = "Poland", TelephoneNumber = 794219755 });
            resortList.Add(new Resort() { Name = "Resort Gdańsk1", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });
            resortList.Add(new Resort() { Name = "Resort Gdańsk2", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });
            resortList.Add(new Resort() { Name = "Resort Gdańsk3", City = "Gdańsk", Country = "Poland", TelephoneNumber = 794219754 });


            foreach (var resort in resortList)
            {

                foreach (var hh in homesList)
                {
                    resort.HolidayHomes.Add(hh);
                }



            }






            List<Hotel> hotelList = new List<Hotel>();
            hotelList.Add(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            hotelList.Add(new Hotel() { Name = "Hotel Warszawa", City = "Warszawa", Country = "Poland", TelephoneNumber = 777888555 });
            hotelList.Add(new Hotel() { Name = "Hotel Katowice", City = "Katowice", Country = "Poland", TelephoneNumber = 777888444 });


















            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(x => x.GetUserById(It.IsAny<string>())).Returns(new ApplicationUser() { UserName = "User1", Id = "aaa-bbb-ccc" });
            mock.Setup(x => x.GetListHHByCountryAndCity(It.IsAny<string>(), It.IsAny<string>())).Returns(homesList);

            List<Hotel> listHotel = new List<Hotel>() { new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 } };

            Mock<IFiltrFactory> mockfactory = new Mock<IFiltrFactory>();
            mockfactory.Setup(f => f.CreateObject(It.IsAny<Choose>())).Returns(new FiltrClassHolidayHome(mock.Object));

            Mock<FiltrResortHotel> mockAbstract2 = new Mock<FiltrResortHotel>();
            //mockAbstract2.Setup(x => x.Hotels).Returns(listHotel);



            Mock<FiltrRoomHolidayHome> mockAbstract = new Mock<FiltrRoomHolidayHome>();
            //mockAbstract.Setup(x => x.HolidayHomes).Returns(homesList);

            //mock.Setup(x => x.GetHotelByID(It.IsAny<int>())).Returns(new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 });
            //mock.Setup(x => x.GetResortByID(It.IsAny<int>())).Returns(new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 });
            //mock.Setup(x => x.AddComment(null, It.IsAny<Hotel>(), It.IsAny<ApplicationUser>(), It.IsAny<string>())).Returns(true);
            HomeController controller = new HomeController(mock.Object, () => "aaa-bbb-ddd", mockAbstract2.Object, mockfactory.Object, mockAbstract.Object);



            ViewResult result = ((ViewResult)controller.FiltrRoomAndHolidayHomeSecond("Poland", "Kraków", Choose.HolidayHome, 1, 2, new DateTime(2019, 8, 25), new DateTime(2019, 8, 26), homesList, roomList));

            SearchModelView viewModel = (SearchModelView)result.Model;


            Assert.AreEqual(viewModel.holidayhomes.Count, 2);
            Assert.AreEqual(viewModel.rooms.Count, 0);




        }


        [Test]
        public void when_calling_ShowDetailsHolidayHome_with_id_it_returns_specified_model()
        {

            HolidayHome hhome = new HolidayHome() { HolidayHomeId = 1, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetHolidayHomeById(It.IsAny<int>())).Returns(hhome);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)(controller.ShowDetailsHolidayHome(1));

            Assert.AreEqual(result.Model, hhome);



        }


        [Test]
        public void when_calling_ShowDetailsParking_with_id_it_returns_specified_model()
        {

            Parking parking = new Parking() { Guarded = true, parkingPlaces = 10, pricePerDay = 10m };


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetParkingById(It.IsAny<int>())).Returns(parking);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)(controller.ShowDetailsParking(1));

            Assert.AreEqual(result.Model, parking);



        }


        [Test]
        public void when_calling_ShowDetailsRoom_with_id_it_returns_specified_model()
        {

            Room room = new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetRoomById(It.IsAny<int>())).Returns(room);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)(controller.ShowDetailsRoom(1));

            Assert.AreEqual(result.Model, room);



        }



        [Test]
        public void when_calling_ShowDetailsHotel_with_id_it_returns_specified_model()
        {

            Hotel hotel = new Hotel() { Name = "Hotel Kraków", City = "Kraków", Country = "Poland", TelephoneNumber = 777888666 };


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetHotelByID(It.IsAny<int>())).Returns(hotel);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)(controller.ShowDetailsHotel(1));

            Assert.AreEqual(result.Model, hotel);



        }


        [Test]
        public void when_calling_ShowDetailsResort_with_id_it_returns_specified_model()
        {

            Resort resort = new Resort() { Name = "Resort Władysławowo", City = "Władysławowo", Country = "Poland", TelephoneNumber = 794219756 };


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();

            mock.Setup(r => r.GetResortByID(It.IsAny<int>())).Returns(resort);

            HomeController controller = new HomeController(mock.Object);

            ViewResult result = (ViewResult)(controller.ShowDetailsResort(1));

            Assert.AreEqual(result.Model, resort);



        }


        /////// ClientController Tests

        [Test]
        public void when_calling_BookHolidayHome_with_specified_Id_returns_model()
        {
            HolidayHome hhome = new HolidayHome() { HolidayHomeId = 1, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };
            List<DateTime> listDateTime = new List<DateTime>();
            listDateTime.Add(new DateTime(2019, 4, 9));
            listDateTime.Add(new DateTime(2019, 4, 10));
            listDateTime.Add(new DateTime(2019, 4, 11));
            listDateTime.Add(new DateTime(2019, 4, 12));


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.GetHolidayHomeById(It.IsAny<int>())).Returns(hhome);
            mock.Setup(r => r.GetDaysBookedHolidayHome(It.IsAny<int>())).Returns(listDateTime);


            ClientController controller = new ClientController(mock.Object);

            ViewResult result = (ViewResult)(controller.BookHolidayHome(1));

            BookViewModel model = (BookViewModel)result.Model;

            Assert.AreEqual(model.holidayhome, hhome);
            Assert.AreEqual(model.list.Count, listDateTime.Count);


        }


        [Test]
        public void when_calling_BookRoom_with_specified_Id_returns_model()
        {

            Room room = new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };

            List<DateTime> listDateTime = new List<DateTime>();
            listDateTime.Add(new DateTime(2019, 4, 9));
            listDateTime.Add(new DateTime(2019, 4, 10));
            listDateTime.Add(new DateTime(2019, 4, 11));
            listDateTime.Add(new DateTime(2019, 4, 12));


            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.GetRoomById(It.IsAny<int>())).Returns(room);
            mock.Setup(r => r.GetDaysBookedRoom(It.IsAny<int>())).Returns(listDateTime);


            ClientController controller = new ClientController(mock.Object);

            ViewResult result = (ViewResult)(controller.BookRoom(1));

            BookRoomViewModel model = (BookRoomViewModel)result.Model;

            Assert.AreEqual(model.room, room);
            Assert.AreEqual(model.list.Count, listDateTime.Count);


        }

        [Test]
        public void when_calling_ReserveHolidayHome_returns_model()
        {

            CheckBookingModel model = new CheckBookingModel();
            model.Available = true;
            model.DaysAvailable = 3;
            model.FirstDateAvailable = new DateTime(2019, 4, 13);
            model.room = new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };
            model.holidayHome = new HolidayHome() { HolidayHomeId = 3, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };


            ReverveHolidayHomeModel reservemodel = new ReverveHolidayHomeModel();
            reservemodel.dateFrom = new DateTime(2019, 4, 2);
            reservemodel.dateTo = new DateTime(2019,4, 5);
            reservemodel.holidayhomeId = 3;



            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.bookholidayhome(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(model);

            ClientController controller = new ClientController(mock.Object);
            RedirectToRouteResult result = (RedirectToRouteResult)(controller.ReserveHolidayHome(reservemodel));

            Assert.AreEqual("ShowDetailsHolidayHome", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
           Assert.AreEqual(3, result.RouteValues["Id"]);






        }


      


        [Test]
        public void when_calling_ReserveHolidayHome_with_model_error_returns_BookViewModel()
        {

            //CheckBookingModel model = new CheckBookingModel();
            //model.Available = true;
            //model.DaysAvailable = 3;
            //model.FirstDateAvailable = new DateTime(2019, 4, 13);
            //model.room = new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };
            //model.holidayHome = new HolidayHome() { HolidayHomeId = 3, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };
            HolidayHome hhome = new HolidayHome() { HolidayHomeId = 3, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };

            List<DateTime> listDateTime = new List<DateTime>();
            listDateTime.Add(new DateTime(2019, 4, 9));
            listDateTime.Add(new DateTime(2019, 4, 10));
            listDateTime.Add(new DateTime(2019, 4, 11));
            listDateTime.Add(new DateTime(2019, 4, 12));




            ReverveHolidayHomeModel reservemodel = new ReverveHolidayHomeModel();
            reservemodel.dateFrom = new DateTime(2019, 4, 6);
            reservemodel.dateTo = new DateTime(2019, 4, 5);
            reservemodel.holidayhomeId = 3;





            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.GetHolidayHomeById(It.IsAny<int>())).Returns(hhome);
            mock.Setup(r => r.GetDaysBookedHolidayHome(It.IsAny<int>())).Returns(listDateTime);


            ClientController controller = new ClientController(mock.Object);
            ViewResult result = (ViewResult)(controller.ReserveHolidayHome(reservemodel));

            Assert.AreEqual("~/Views/Client/BookHolidayHome.cshtml", result.ViewName);
            BookViewModel bookviewmodel = (BookViewModel)result.Model;

            Assert.AreEqual(hhome, bookviewmodel.holidayhome);






        }


        [Test]
        public void when_calling_ReserveRoom_returns_model()
        {

            CheckBookingModel model = new CheckBookingModel();
            model.Available = true;
            model.DaysAvailable = 3;
            model.FirstDateAvailable = new DateTime(2019, 4, 13);
            model.room = new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };
            model.holidayHome = new HolidayHome() { HolidayHomeId = 3, Price = 200, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = true, Toilet = true, Kitchen = false, numberofTelevisions = 1, numberofFloors = 1 };


            ReverveRoomModel reservemodel = new ReverveRoomModel();
            reservemodel.dateFrom = new DateTime(2019, 4, 2);
            reservemodel.dateTo = new DateTime(2019, 4, 5);
            reservemodel.roomId = 3;



            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.bookroom(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(model);

            ClientController controller = new ClientController(mock.Object);
            RedirectToRouteResult result = (RedirectToRouteResult)(controller.ReserveRoom(reservemodel));

            Assert.AreEqual("ShowDetailsRoom", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
            Assert.AreEqual(3, result.RouteValues["Id"]);






        }


        [Test]
        public void when_calling_ReserveRoom_with_model_error_returns_BookRoomViewModel()
        {

          Room room= new Room() { Price = 100, numberofGuests = 1, numberofBeds = 1, doubleBed = false, petsAllowed = false, Toilet = true, Kitchen = false, numberofTelevisions = 1 };

            List<DateTime> listDateTime = new List<DateTime>();
            listDateTime.Add(new DateTime(2019, 4, 9));
            listDateTime.Add(new DateTime(2019, 4, 10));
            listDateTime.Add(new DateTime(2019, 4, 11));
            listDateTime.Add(new DateTime(2019, 4, 12));




            ReverveRoomModel reservemodel = new ReverveRoomModel();
            reservemodel.dateFrom = new DateTime(2019, 4, 5);
            reservemodel.dateTo = new DateTime(2019, 4, 2);
            reservemodel.roomId = 3;





            Mock<IHolidaysRepository> mock = new Mock<IHolidaysRepository>();
            mock.Setup(r => r.GetRoomById(It.IsAny<int>())).Returns(room);
            mock.Setup(r => r.GetDaysBookedRoom(It.IsAny<int>())).Returns(listDateTime);


            ClientController controller = new ClientController(mock.Object);
            ViewResult result = (ViewResult)(controller.ReserveRoom(reservemodel));

            Assert.AreEqual("~/Views/Client/BookRoom.cshtml", result.ViewName);
            BookRoomViewModel bookviewmodel = (BookRoomViewModel)result.Model;

            Assert.AreEqual(room, bookviewmodel.room);






        }




    }
}
