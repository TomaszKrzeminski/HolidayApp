using HolidayApp.Abstract;
using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
    public enum Choose
    {
        Room, HolidayHome
    }


    public abstract class FiltrRoomHolidayHome
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        public Choose choose { get; set; }
        public int GuestNumber { get; set; }
        public int BedNumber { get; set; }
        public DateTime BookFrom {
            get;
            set;
        }
        public DateTime BookTo {
            get;
            set;
        }

        public List<Room> Rooms { get; set; }
        public List<HolidayHome> HolidayHomes { get; set; }

        public virtual List<Room> GetRooms()
        {
            return new List<Room>();
        }

        public virtual List<HolidayHome> GetHolidayHomes()
        {
            return new List<HolidayHome>();
        }

        public virtual void FiltrByCountryAndCity()
        {

        }

        public virtual void FiltrByRoom()
        {

        }
        public virtual void FiltrByHolidayHome()
        {

        }
        public virtual void FiltrByGuestNumber()
        {

        }
        public virtual void FiltrByBedNumber()
        {

        }

        public virtual void FiltrByDate()
        {

        }

        public


        void Filtr()
        {
            FiltrByCountryAndCity();
            FiltrByRoom();
            FiltrByHolidayHome();
            FiltrByGuestNumber();
            FiltrByBedNumber();
            FiltrByDate();
        }

    }



    public class FiltrClassHolidayHome : FiltrRoomHolidayHome
    {
        IHolidaysRepository repository;



        public FiltrClassHolidayHome(IHolidaysRepository param)
        {
            GuestNumber = 0;
            BedNumber = 0;
            repository = param;
            Rooms = new List<Room>();

        }


        public override void FiltrByCountryAndCity()
        {
            if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Country))
            {
                HolidayHomes = repository.GetListHHByCountryAndCity(Country, City);
            }

        }


        public override void FiltrByGuestNumber()
        {
            if (GuestNumber > 0)
            {
                HolidayHomes = HolidayHomes.Where(g => g.numberofGuests == GuestNumber).ToList();
            }

        }
        public override void FiltrByBedNumber()
        {
            if (BedNumber > 0)
            {
                HolidayHomes = HolidayHomes.Where(b => b.numberofBeds == BedNumber).ToList();
            }

        }


        public override void FiltrByDate()
        {
            List<HolidayHome> listofHolidayHomes = new List<HolidayHome>(HolidayHomes);
            List<DateTime> timeinterval = new List<DateTime>();

            if(BookFrom==DateTime.MinValue)
            {
                BookFrom = DateTime.Now.AddDays(1);
            }

            if(BookTo==DateTime.MinValue)
            {
                BookTo = BookFrom.AddMonths(1);
            }


            int nightsCount = (int)Math.Round((BookTo - BookFrom).TotalDays);
          
            for (int i = 0; i < nightsCount; i++)
            {

                DateTime dayinter = BookFrom;
                dayinter = dayinter.AddHours(16);
                dayinter = dayinter.AddDays(i);
                timeinterval.Add(dayinter);
            }



            foreach (var holidayhome in HolidayHomes)
            {


                foreach (var reservetime in holidayhome.reserveTimes)
                {




                    foreach (var day in timeinterval)
                    {

                        if(day>=reservetime.bookingFrom&&day<=reservetime.bookingToo)
                        {
                            listofHolidayHomes.Remove(holidayhome);
                        }
                       
                    }



                }




            }




            HolidayHomes = listofHolidayHomes;


        }



    }

    public class FiltrClassRoom : FiltrRoomHolidayHome
    {

        IHolidaysRepository repository;



        public FiltrClassRoom(IHolidaysRepository param)
        {
            GuestNumber = 0;
            BedNumber = 0;
            repository = param;
            HolidayHomes = new List<HolidayHome>();

        }


        public override void FiltrByCountryAndCity()
        {
            if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Country))
                Rooms = repository.GetListRByCountryAndCity(Country, City);
        }


        public override void FiltrByGuestNumber()
        {
            if (GuestNumber > 0)
            {
                Rooms = Rooms.Where(g => g.numberofGuests == GuestNumber).ToList();
            }

        }
        public override void FiltrByBedNumber()
        {
            if (BedNumber > 0)
            {
                Rooms = Rooms.Where(b => b.numberofBeds == BedNumber).ToList();
            }

        }

        public override void FiltrByDate()
        {
            List<Room> listofRooms = new List<Room>(Rooms);
            
            List<DateTime> timeinterval = new List<DateTime>();

            if (BookFrom == null)
            {
                BookFrom = DateTime.Now.AddDays(1);
            }

            if (BookTo == null)
            {
                BookTo = BookFrom.AddMonths(1);
            }


            int nightsCount = (int)Math.Round((BookTo - BookFrom).TotalDays);

 
            for (int i = 0; i < nightsCount; i++)
            {

               DateTime dayinter = BookFrom;
                dayinter= dayinter.AddHours(16);
                dayinter= dayinter.AddDays(i);
                timeinterval.Add(dayinter);
            }



            foreach (var room in Rooms)
                     
            {
              

                foreach (var reservetime in room.reserveTimes)
                {




                    foreach (var day in timeinterval)
                    {

                        if (day >= reservetime.bookingFrom && day <= reservetime.bookingToo)
                        {
                            
                            listofRooms.Remove(room);
                        }

                    }



                }




            }




           Rooms = listofRooms;


        }



    }



}
