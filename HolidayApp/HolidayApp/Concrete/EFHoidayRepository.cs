using HolidayApp.Abstract;
using HolidayApp.Entities;
using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace HolidayApp.Concrete
{
    public class EFHolidayRepository : IHolidaysRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public bool AddHolidayHomeToResort(HolidayHome holidayhome, int id)
        {



            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.HolidayHomes.Add(holidayhome);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }



        }

        public bool AddHotel(Hotel hotel, string UserId)
        {

            try
            {
                ApplicationUser user = context.Users.Find(UserId);

                user.Hotels.Add(hotel);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }



        public bool AddParkingToHotel(Parking parking, int id)
        {

            try
            {
                Hotel hotel = context.Hotels.Find(id);
                hotel.Parkings.Add(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }



        }

        public bool AddParkingToResort(Parking parking, int id)
        {
            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.Parkings.Add(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public string AddPictureHolidayHome(int Id, string Path)
        {
           

          
                HolidayHome home = context.HolidayHomes.Find(Id);
                int count = home.Images.Count();
                if (count > 5)
                {
                return "";
                }

                


            try
            {
                HolidayHome entity = context.HolidayHomes.Find(Id);
                Image image = new Image();

                string ResortId=  entity.Resort.ResortId.ToString();

                string text = "\\Resort" + ResortId + "HolidayHome"+entity.HolidayHomeId+"Picturenr" + (count + 1).ToString()+".jpg";

                image.ImagePath = "~\\Images" + text ;


                entity.Images.Add(image);
                context.SaveChanges();
                return text;
            }
            catch
            {
                return "";
            }
        }


       






        public string AddPictureHotel(int Id, string Path)
        {



            int count = 0;
           

            Hotel hotel = context.Hotels.Find(Id);
            count = hotel.Images.Count();
            if (count > 5)
            {
                return "";
            }




            try
            {
                Hotel entity = context.Hotels.Find(Id);
                Image image = new Image();

               

                string text = "\\Hotel" + entity.HotelId + "Picturenr" + (count + 1).ToString() + ".jpg";

                image.ImagePath = "~\\Images" + text;
                entity.Images.Add(image);
                context.SaveChanges();
                return text;
            }
            catch
            {
                return "";
            }
        }

        public string AddPictureParking(int Id, string Path)
        {
            int count = 0;
            string text="";
            Parking data = context.Parkings.Find(Id);
            count = data.Images.Count();
            if (count > 5)
            {
                return "";
            }

           

            try
            {
                Parking entity = context.Parkings.Find(Id);
                Image image = new Image();

                if(entity.Hotel==null)
                {
                    text = "\\Resort" + entity.Resort.ResortId;
                }
                else
                {
                    text = "\\Hotel" + entity.Hotel.HotelId;
                }

                text += "Parking" + entity.ParkingId + "Picturenr" + (count + 1).ToString() + ".jpg";

                image.ImagePath = "~\\Images" + text;
                entity.Images.Add(image);
                context.SaveChanges();
                return text;
            }
            catch
            {
                return "";
            }
        }

        public string AddPictureResort(int Id, string Path)
        {

            int count = 0;

            Resort data = context.Resorts.Find(Id);
            count = data.Images.Count();
            if (count > 5)
            {
                return "";
            }

            try
            {
                Resort entity = context.Resorts.Find(Id);
                Image image = new Image();

                string text = "\\Resort" + entity.ResortId + "Picturenr" + (count + 1).ToString() + ".jpg";

                image.ImagePath = "~\\Images" + text;
                entity.Images.Add(image);
                context.SaveChanges();
                return text;
            }
            catch
            {
                return "";
            }
        }

        public string AddPictureRoom(int Id, string Path)
        {
            int count = 0;
            string text = "";

            Room data = context.Rooms.Find(Id);
            count = data.Images.Count();
            if (count > 5)
            {
                return "";
            }





            try
            {
                Room entity = context.Rooms.Find(Id);
                Image image = new Image();


                if (entity.Hotel == null)
                {
                    text = "\\Resort" + entity.Resort.ResortId;
                }
                else
                {
                    text = "\\Hotel" + entity.Hotel.HotelId;
                }

                text += "Room" + entity.RoomId + "Picturenr" + (count + 1).ToString() + ".jpg";



                image.ImagePath = "~\\Images" + text;
                entity.Images.Add(image);
                context.SaveChanges();
                return text;
            }
            catch
            {
                return "";
            }
        }

        public bool AddResort(Resort resort, string UserId)
        {

            try
            {
                ApplicationUser user = context.Users.Find(UserId);

                user.Resorts.Add(resort);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }






        }

        public bool AddRoomToHotel(Room room, int id)
        {
            try
            {
                Hotel hotel = context.Hotels.Find(id);
                hotel.Rooms.Add(room);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool AddRoomToResort(Room room, int id)
        {

            try
            {
                Resort resort = context.Resorts.Find(id);
                resort.Rooms.Add(room);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }




        }

        public bool ChangeHotel(Hotel hotel)
        {

            Hotel hotelChange = context.Hotels.Find(hotel.HotelId);
            hotelChange.Name = hotel.Name;
            hotelChange.City = hotel.City;
            hotelChange.Country = hotel.Country;
            hotelChange.TelephoneNumber = hotel.TelephoneNumber;
            context.SaveChanges();
            return true;





        }

        public bool ChangeResort(Resort resort)
        {
            Resort resortChange = context.Resorts.Find(resort.ResortId);
            resortChange.Name = resort.Name;
            resortChange.City = resort.City;
            resortChange.Country = resort.Country;
            resortChange.TelephoneNumber = resort.TelephoneNumber;
            context.SaveChanges();
            return true;



        }

       

        public List<Image> GetAllImagesHolidayHome(int Id)
        {
            List<Image> images = new List<Image>();
            try
            {
                images = context.HolidayHomes.Find(Id).Images.ToList();
                return images;
            }
            catch
            {
                return images;
            }
        }

        public List<Image> GetAllImagesHotel(int Id)
        {
            List<Image> images = new List<Image>();
            try
            {
                images = context.Hotels.Find(Id).Images.ToList();
                return images;
            }
            catch
            {
                return images;
            }
        }

        public List<Image> GetAllImagesParking(int Id)
        {
            List<Image> images = new List<Image>();
            try
            {
                images = context.Parkings.Find(Id).Images.ToList();
                return images;
            }
            catch
            {
                return images;
            }
        }

        public List<Image> GetAllImagesResort(int Id)
        {
            List<Image> images = new List<Image>();
            try
            {
                images = context.Resorts.Find(Id).Images.ToList();
                return images;
            }
            catch
            {
                return images;
            }
        }

        public List<Image> GetAllImagesRoom(int Id)
        {
            List<Image> images = new List<Image>();
            try
            {
                images = context.Rooms.Find(Id).Images.ToList();
                return images;
            }
            catch
            {
                return images;
            }
        }

        public HolidayHome GetHolidayHomeById(int id)
        {
            try
            {
                HolidayHome holidayHome = context.HolidayHomes.Find(id);
                return holidayHome;

            }
            catch
            {
                return new HolidayHome();
            }
        }

        public Hotel GetHotelByID(int id)
        {
            Hotel hotel = new Hotel();
            try
            {

                hotel = context.Hotels.Find(id);
                return hotel;

            }
            catch
            {
                return hotel;
            }


        }

        public Image GetImageByIdHolidayHome(int Id, int TypeId)
        {
            try
            {
                Image image = context.HolidayHomes.Where(x => x.HolidayHomeId == TypeId).FirstOrDefault().Images.Where(x => x.ImageId == Id).FirstOrDefault();
                return image;
            }
            catch (Exception ex)
            {
                return new Image();
            }
        }

        public Image GetImageByIdHotel(int Id,int TypeId)
        {
            
            try
            {
                Image image = context.Hotels.Where(x => x.HotelId == TypeId).FirstOrDefault().Images.Where(x => x.ImageId == Id).FirstOrDefault();
                return image;
            }
            catch(Exception ex)
            {
              return  new Image();
            }


        }

        public Image GetImageByIdParking(int Id, int TypeId)
        {
            try
            {
                Image image = context.Parkings.Where(x => x.ParkingId == TypeId).FirstOrDefault().Images.Where(x => x.ImageId == Id).FirstOrDefault();
                return image;
            }
            catch (Exception ex)
            {
                return new Image();
            }
        }

        public Image GetImageByIdResort(int Id, int TypeId)
        {
            try
            {
                Image image = context.Resorts.Where(x => x.ResortId == TypeId).FirstOrDefault().Images.Where(x => x.ImageId == Id).FirstOrDefault();
                return image;
            }
            catch (Exception ex)
            {
                return new Image();
            }
        }

        public Image GetImageByIdRoom(int Id, int TypeId)
        {
            try
            {
                Image image = context.Rooms.Where(x => x.RoomId == TypeId).FirstOrDefault().Images.Where(x => x.ImageId == Id).FirstOrDefault();
                return image;
            }
            catch (Exception ex)
            {
                return new Image();
            }
        }

        public List<HolidayHome> GetListHHByCountryAndCity(string Country,string City)
        {
            List<HolidayHome> list = new List<HolidayHome>();
            try
            {
                List<Resort> listResort = context.Resorts.Where(x => x.Country == Country).ToList();
                listResort= listResort.Where(x => x.City == City).ToList();
                foreach (var item in listResort)
                {
                    list.AddRange(item.HolidayHomes);
                }

                return list;

            }
            catch
            {
                return list;
            }
        }

        public List<Room> GetListRByCountryAndCity(string Country,string City)
        {

            List<Room> list = new List<Room>();
            try
            {
                List<Hotel> listHotel = context.Hotels.Where(x => x.Country == Country).ToList();
                listHotel = listHotel.Where(x => x.City == City).ToList();
                foreach (var item in listHotel)
                {
                    list.AddRange(item.Rooms);
                }

                return list;

            }
            catch
            {
                return list;
            }




        }

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
                    catch (Exception ex)
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
                    catch (Exception ex)
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

        public Parking GetParkingById(int id)
        {

            try
            {

                Parking parking = context.Parkings.Find(id);
                return parking;

            }
            catch
            {
                return new Parking();
            }



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



            for (int i = 0; i < 10; i++)
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
                    Hotel hotel = context.Hotels.Find(HotelNumber[i]);

                    if(hotel!=null)
                    {
                     viewModel.HotelList.Add(hotel);
                    }
                   
                    
                }
                catch
                {
                    viewModel.HotelList.Add(new Hotel());
                }


                try
                {
                    Resort resort =context.Resorts.Find(ResortNumber[i]);
                    if(resort!=null)
                    {
viewModel.ResortList.Add(resort);
                    }
                    
                }
                catch
                {
                    viewModel.ResortList.Add(new Resort());
                }

                try
                {
                    Room room =context.Rooms.Find(RoomNumber[i]);
                    if(room!=null)
                    {
viewModel.RoomList.Add(room);
                    }
                    
                }
                catch
                {

                    viewModel.RoomList.Add(new Room());
                }


            }


            return viewModel;


        }

        public Resort GetResortByID(int id)
        {

            try
            {
                Resort resort = context.Resorts.Find(id);
                return resort;
            }
            catch
            {
                return new Resort();
            }


        }

        public Room GetRoomById(int id)
        {

            try
            {
                Room room = context.Rooms.Find(id);
                return room;

            }
            catch
            {
                return new Room();
            }
        }

        public bool RemoveHolidayHome(int id)
        {
            try
            {
                HolidayHome holidayHome = context.HolidayHomes.Find(id);
                if(holidayHome.Images.Count>0)
                {
                    List<Image> images = holidayHome.Images.ToList();
                    
                    foreach (var item in images)
                    {
                        holidayHome.Images.Remove(item);
                    }
                    context.SaveChanges();

                }
                context.HolidayHomes.Remove(holidayHome);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool RemoveHotel(int id)
        {

            try
            {

                Hotel hotel = context.Hotels.Find(id);


                List<Parking> parkingList = hotel.Parkings.ToList();
                List<Room> roomList = hotel.Rooms.ToList();


                if (hotel.Images.Count > 0)
                {
                    List<Image> images = hotel.Images.ToList();

                    foreach (var item in images)
                    {
                        hotel.Images.Remove(item);
                    }
                    context.SaveChanges();

                }




                if (parkingList.Count > 0)
                {

                    

                    foreach (var item in parkingList)
                    {

                      



                        context.Parkings.Remove(item);
                        context.SaveChanges();
                    }

                }


                if (roomList.Count > 0)
                {

                    foreach (var item in roomList)
                    {
                        context.Rooms.Remove(item);
                        context.SaveChanges();
                    }



                }



                context.Hotels.Remove(hotel);
                context.SaveChanges();
                return true;






            }
            catch (Exception ex)
            {
                return false;
            }





        }

        public bool RemoveParking(int id)
        {


            try
            {
                Parking parking = context.Parkings.Find(id);
                if (parking.Images.Count > 0)
                {
                    List<Image> images = parking.Images.ToList();

                    foreach (var item in images)
                    {
                        parking.Images.Remove(item);
                    }
                    context.SaveChanges();

                }

                context.Parkings.Remove(parking);
                context.SaveChanges();
                return true;

            }
            catch
            {

                return false;

            }

        }

        public bool RemoveResort(int id)
        {


            try
            {

                Resort resort = context.Resorts.Find(id);


                List<Parking> parkingList = resort.Parkings.ToList();
                List<Room> roomList = resort.Rooms.ToList();
                List<HolidayHome> holidayHomeList = resort.HolidayHomes.ToList();



                if (resort.Images.Count > 0)
                {
                    List<Image> images = resort.Images.ToList();

                    foreach (var item in images)
                    {
                        resort.Images.Remove(item);
                    }
                    context.SaveChanges();

                }


                if (parkingList.Count > 0)
                {
                    foreach (var item in parkingList)
                    {
                        context.Parkings.Remove(item);
                        context.SaveChanges();
                    }

                }


                if (roomList.Count > 0)
                {

                    foreach (var item in roomList)
                    {
                        context.Rooms.Remove(item);
                        context.SaveChanges();
                    }



                }


                if (holidayHomeList.Count > 0)
                {

                    foreach (var item in holidayHomeList)
                    {
                        context.HolidayHomes.Remove(item);
                        context.SaveChanges();
                    }


                }



                context.Resorts.Remove(resort);
                context.SaveChanges();
                return true;






            }
            catch (Exception ex)
            {
                return false;
            }










        }

        public bool RemoveRoom(int id)
        {


            try
            {
                Room room = context.Rooms.Find(id);

                if (room.Images.Count > 0)
                {
                    List<Image> images = room.Images.ToList();

                    foreach (var item in images)
                    {
                        room.Images.Remove(item);
                    }
                    context.SaveChanges();

                }






                context.Rooms.Remove(room);
                context.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }



        }
    }
}