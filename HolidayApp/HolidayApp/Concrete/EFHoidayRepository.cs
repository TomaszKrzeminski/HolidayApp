using HolidayApp.Abstract;
using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Concrete
{
    public class EFHolidayRepository : IHolidaysRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public HolidayViewModel GetModelByUser(string UserId)
        {

            List<Room> roomList = new List<Room>();
            List<Hotel> hotelList = new List<Hotel>();
            List<Resort> resortList = new List<Resort>();




            try
            {
                hotelList = context.Hotels.Include("Rooms").Where(x => x.ApplicationUserID == UserId).ToList();
            }
            catch
            {

            }

            try
            {
                resortList = context.Resorts.Include("Rooms").Where(x => x.ApplicationUserID == UserId).ToList();
            }
            catch
            {

            }



            if (hotelList.Count > 0)
            {

                foreach (var item in hotelList)
                {
                    try
                    {
                        roomList.AddRange(item.Rooms);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }


            }


            if (resortList.Count > 0)
            {

                foreach (var item in resortList)
                {
                    try
                    {
                        roomList.AddRange(item.Rooms);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }



            }






            HolidayViewModel model = new HolidayViewModel();

            model.ResortList = resortList;
            model.HotelList = hotelList;
            model.RoomList = roomList;



            return model;

        }


        public HolidayViewModel GetRandomPlaces()
        {

            Random random = new Random();
            int countResort = 0;
            int countHotel = 0;
            int countRoom = 0;

            List<int> ResortNumber = new List<int>();
            List<int> HotelNumber = new List<int>();
            List<int> RoomNumber = new List<int>();

            HolidayViewModel viewModel = new HolidayViewModel();




            try
            {
                countResort = context.Resorts.Count();
                countHotel = context.Hotels.Count();
                countRoom = context.Rooms.Count();
            }
            catch (Exception ex)
            {

                return new HolidayViewModel();

            }



            for (int i = 0; i < 4; i++)
            {
                if (countResort > 0)
                {
                    ResortNumber.Add(random.Next(1, countResort));
                }

                if (countHotel > 0)
                {
                    HotelNumber.Add(random.Next(1, countHotel));
                }

                if (countRoom > 0)
                {
                    RoomNumber.Add(random.Next(1, countRoom));
                }


            }


            ResortNumber = ResortNumber.Distinct().Take(2).ToList();
            HotelNumber = HotelNumber.Distinct().Take(2).ToList();
            RoomNumber = RoomNumber.Distinct().Take(2).ToList();



            for (int i = 0; i < 2; i++)
            {


                try
                {
                    viewModel.HotelList.Add(context.Hotels.Find(HotelNumber[i]));
                }
                catch
                {

                }


                try
                {
                    viewModel.ResortList.Add(context.Resorts.Find(ResortNumber[i]));
                }
                catch
                {

                }

                try
                {
                    viewModel.RoomList.Add(context.Rooms.Find(RoomNumber[i]));
                }
                catch
                {


                }


            }


            return viewModel;


        }
    }
}