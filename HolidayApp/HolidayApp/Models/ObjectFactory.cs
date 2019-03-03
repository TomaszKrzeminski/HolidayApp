using HolidayApp.Abstract;
using HolidayApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HolidayApp.Models
{
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
                        break;

                    case "Resorttype":
                        return new Resort(repository);
                        break;
                case "Roomtype":
                    return new Room(repository);
                    break;
                case "HolidayHometype":
                    return new HolidayHome(repository);
                    break;
                case "Parkingtype":
                    return new Parking(repository);
                    break;

                default:
                        throw new ArgumentException();
                }
            }
     



    }
}