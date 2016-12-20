using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace Data.Repositories
{
    public class HotelRepository
    {
        public static List<Hotel> GetAllHotels()
        {
            using(var context = new Hoteldb())
            {
                return context.Hotels.OrderBy(x => Guid.NewGuid()).ToList();
            }
        }

        public Hotel GetSpecificHotelInfo(int? hid)
        {
            using (var context = new Hoteldb())
            {
                //var hotel = new Hotel();
                // lol


                return context.Hotels.FirstOrDefault(x => x.HID == hid);
            }
        }

        public static void RemoveSpecificHotel(int? hid)
        {
            using (var context = new Hoteldb())
            {
                var hotel = context.Hotels.FirstOrDefault(x => x.HID == hid);
                context.Hotels.Remove(hotel);
                context.SaveChanges();
            }
        }

        public List<Room> GetAllRoomsFromSpecificHotel(int? hid)
        {
            using (var context = new Hoteldb())
            {
                var result = context.Rooms

                    .OrderBy(x => x.Room_Number)
                    .Where(x => x.HID == hid)
                    .ToList();

                return result;
            }
        }

        public HotelPic GetHotelImage(int? hid)
        {
            using (var context = new Hoteldb())
            {
                return context.HotelPics.FirstOrDefault(x => x.HID == hid);
            }
        }

        
    }
}
