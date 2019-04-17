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
        public DateTime BookFrom
        {
            get;
            set;
        }
        public DateTime BookTo
        {
            get;
            set;
        }

        public virtual List<Room> Rooms { get; set; }
        public virtual List<HolidayHome> HolidayHomes { get; set; }

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

    public abstract class FiltrResortHotel
    {
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }

        public int GuestNumber { get; set; }
        public int BedNumber { get; set; }
        public DateTime BookFrom
        {
            get;
            set;
        }
        public DateTime BookTo
        {
            get;
            set;
        }

        public virtual List<Hotel> Hotels { get; set; }
        public virtual List<Resort> Resorts { get; set; }
        /// 

        public Dictionary<Hotel, List<Room>> HotelListOfRooms { get; set; }
        public Dictionary<Resort, List<HolidayHome>> ResortListOfHolidayHomes { get; set; }
        public Dictionary<Resort, List<Room>> ResortListOfRooms { get; set; }

        /// <summary>


        public virtual List<Hotel> GetHotels()
        {
            return new List<Hotel>();
        }

        public virtual List<Resort> GetResorts()
        {
            return new List<Resort>();
        }

        public virtual void FiltrByCountryAndCity()
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
            FiltrByGuestNumber();
            FiltrByBedNumber();
            FiltrByDate();
        }

    }

    public class FiltrClassResortHotel : FiltrResortHotel
    {
        IHolidaysRepository repository;



        public FiltrClassResortHotel(IHolidaysRepository param)
        {
            GuestNumber = 0;
            BedNumber = 0;
            repository = param;
            Hotels = new List<Hotel>();
            Resorts = new List<Resort>();
            HotelListOfRooms = new Dictionary<Hotel, List<Room>>();
            ResortListOfHolidayHomes = new Dictionary<Resort, List<HolidayHome>>();
            ResortListOfRooms = new Dictionary<Resort, List<Room>>();

        }


        public override void FiltrByCountryAndCity()
        {
            if (!string.IsNullOrEmpty(City) && !string.IsNullOrEmpty(Country))
            {
                Resorts = repository.GetResortsByCountryAndCity(Country, City);
                Hotels = repository.GetHotelsByCountryAndCity(Country, City);

            }

        }


        public override void FiltrByGuestNumber()
        {
            if (GuestNumber > 0)
            {

                if (Resorts != null)
                {

                    List<HolidayHome> list = Resorts.SelectMany(r => r.HolidayHomes).Where(h => h.numberofGuests == GuestNumber).ToList();
                    List<Resort> listresort = list.Select(l => l.Resort).ToList();
                    Resorts = listresort.AsEnumerable<Resort>().Distinct().ToList();
                    List<Room> listroom = Resorts.SelectMany(r => r.Rooms).Where(h => h.numberofGuests == GuestNumber).ToList();
                    List<Resort> listresort2 = list.Select(l => l.Resort).ToList();
                    Resorts.AddRange(listresort2);
                    Resorts = Resorts.AsEnumerable<Resort>().Distinct().ToList();


                }

                if (Hotels != null)
                {

                    List<Room> list = Hotels.SelectMany(r => r.Rooms).Where(h => h.numberofGuests == GuestNumber).ToList();
                    List<Hotel> listhotel = list.Select(l => l.Hotel).ToList();
                    Hotels = listhotel.AsEnumerable<Hotel>().Distinct().ToList();

                }




            }

        }
        public override void FiltrByBedNumber()
        {
            if (BedNumber > 0)
            {

                if (Resorts != null)
                {
                    List<HolidayHome> list = Resorts.SelectMany(r => r.HolidayHomes).Where(h => h.numberofBeds == BedNumber).ToList();
                    List<Resort> listresort = list.Select(l => l.Resort).ToList();
                    Resorts = listresort.AsEnumerable<Resort>().Distinct().ToList();
                    List<Room> listroom = Resorts.SelectMany(r => r.Rooms).Where(h => h.numberofBeds == BedNumber).ToList();
                    List<Resort> listresort2 = list.Select(l => l.Resort).ToList();
                    Resorts.AddRange(listresort2);
                    Resorts = Resorts.AsEnumerable<Resort>().Distinct().ToList();


                }

                if (Hotels != null)
                {
                    List<Room> list = Hotels.SelectMany(r => r.Rooms).Where(h => h.numberofBeds == BedNumber).ToList();
                    List<Hotel> listhotel = list.Select(l => l.Hotel).ToList();
                    Hotels = listhotel.AsEnumerable<Hotel>().Distinct().ToList();


                }


            }

        }


        public override void FiltrByDate()
        {


            if (Resorts != null)
            {

                List<HolidayHome> HolidayHomes = Resorts.SelectMany(x => x.HolidayHomes).ToList();
                List<HolidayHome> listofHolidayHomes = new List<HolidayHome>(HolidayHomes);
                List<DateTime> timeinterval = new List<DateTime>();

                if (BookFrom == DateTime.MinValue)
                {
                    BookFrom = DateTime.Now.AddDays(1);
                }

                if (BookTo == DateTime.MinValue)
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

                            if (day >= reservetime.bookingFrom && day <= reservetime.bookingToo)
                            {
                                listofHolidayHomes.Remove(holidayhome);
                            }

                        }



                    }




                }





                List<Resort> listresort2 = listofHolidayHomes.Select(l => l.Resort).ToList();


                /////////

                List<Room> Rooms = Resorts.SelectMany(h => h.Rooms).ToList();
                List<Room> listofRooms = new List<Room>(Rooms);

                List<DateTime> timeinterval2 = new List<DateTime>();

                if (BookFrom == null)
                {
                    BookFrom = DateTime.Now.AddDays(1);
                }

                if (BookTo == null)
                {
                    BookTo = BookFrom.AddMonths(1);
                }


                int nightsCount2 = (int)Math.Round((BookTo - BookFrom).TotalDays);


                for (int i = 0; i < nightsCount2; i++)
                {

                    DateTime dayinter = BookFrom;
                    dayinter = dayinter.AddHours(16);
                    dayinter = dayinter.AddDays(i);
                    timeinterval2.Add(dayinter);
                }



                foreach (var room in Rooms)

                {


                    foreach (var reservetime in room.reserveTimes)
                    {




                        foreach (var day in timeinterval2)
                        {

                            if (day >= reservetime.bookingFrom && day <= reservetime.bookingToo)
                            {

                                listofRooms.Remove(room);
                            }

                        }



                    }




                }




                Rooms = listofRooms;
                List<Resort> listofResorts = Rooms.Select(x => x.Resort).ToList();
                Resorts = new List<Resort>();
                Resorts.AddRange(listofResorts);
                Resorts.AddRange(listresort2);
                Resorts = Resorts.AsEnumerable<Resort>().Distinct().ToList();


                if (Rooms != null && Rooms.Count > 0)
                {


                    foreach (var resort in Resorts)
                    {

                        List<Room> listDictionary = new List<Room>();

                        foreach (var room in listofRooms)
                        {

                            if (resort.Rooms.Contains(room))
                            {
                                listDictionary.Add(room);
                            }


                        }

                        ResortListOfRooms.Add(resort, listDictionary);
                        listDictionary = new List<Room>();

                    }


                }

                if (HolidayHomes != null && HolidayHomes.Count > 0)
                {


                    foreach (var resort in Resorts)
                    {

                        List<HolidayHome> listDictionary = new List<HolidayHome>();

                        foreach (var holidayhome in listofHolidayHomes)
                        {

                            if (resort.HolidayHomes.Contains(holidayhome))
                            {
                                listDictionary.Add(holidayhome);
                            }


                        }

                        ResortListOfHolidayHomes.Add(resort, listDictionary);


                    }


                }





                /////////

            }

            if (Hotels != null)
            {
                List<Room> Rooms = Hotels.SelectMany(h => h.Rooms).ToList();
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
                    dayinter = dayinter.AddHours(16);
                    dayinter = dayinter.AddDays(i);
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
                Hotels = Hotels.AsEnumerable<Hotel>().Distinct().ToList();



                if (Rooms != null && Rooms.Count > 0)
                {


                    foreach (var hotel in Hotels)
                    {

                        List<Room> listDictionary = new List<Room>();

                        foreach (var room in Rooms)
                        {

                            if (hotel.Rooms.Contains(room))
                            {
                                listDictionary.Add(room);
                            }


                        }

                        HotelListOfRooms.Add(hotel, listDictionary);


                    }


                }


            }




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

            if (BookFrom == DateTime.MinValue)
            {
                BookFrom = DateTime.Now.AddDays(1);
            }

            if (BookTo == DateTime.MinValue)
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

                        if (day >= reservetime.bookingFrom && day <= reservetime.bookingToo)
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
                dayinter = dayinter.AddHours(16);
                dayinter = dayinter.AddDays(i);
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
