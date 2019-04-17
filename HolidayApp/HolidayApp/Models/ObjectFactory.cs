using HolidayApp.Abstract;
using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{


    public interface IFiltrFactory
    {

        FiltrRoomHolidayHome CreateObject(Choose choose);


    }




    public class FiltrFactory: IFiltrFactory
    {
        IHolidaysRepository repository;
        public FiltrFactory(IHolidaysRepository repo)
        {
            repository = repo;
        }

        public FiltrRoomHolidayHome CreateObject(Choose choose)
        {
            switch (choose.ToString())
            {
                case "Room":
                    return new FiltrClassRoom(repository);
                   

                case "HolidayHome":
                    return new FiltrClassHolidayHome(repository);
                  
            

                default:
                    throw new ArgumentException();
            }
        }




    }












    public class ObjectFactory
    {
        IHolidaysRepository repository;
        public ObjectFactory(IHolidaysRepository repo)
        {
            repository = repo;
        }

            public IAddImage CreateObject(string data)
            {
                switch (data)
                {
                    case "Hoteltype":
                        return new Hotel(repository);
                       

                    case "Resorttype":
                        return new Resort(repository);
                       
                case "Roomtype":
                    return new Room(repository);
                    
                case "HolidayHometype":
                    return new HolidayHome(repository);
                   
                case "Parkingtype":
                    return new Parking(repository);
                    

                default:
                        throw new ArgumentException();
                }
            }
     



    }
}