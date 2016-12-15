using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data.Repositories
{
    public class HotelAdminRepository
    {
        public HotelAdmin LoginHotelAdmin(string username, string password)
        {
            using (var context = new Hoteldb())
            {
                return context.HotelAdmins.FirstOrDefault(x =>
                    x.Username.Equals(username) &&
                    x.Password.Equals(password));
            }
        }

        public HotelAdmin GetHotelAdminInfo(string username)
        {
            using (var context = new Hoteldb())
            {
                return context.HotelAdmins.FirstOrDefault(x => x.Username == username);
            }
        }

        public List<Hotel> GetHotelAdminHotels(int adminID)
        {
            var listofhotels = new List<Hotel>();

            using (var context = new Hoteldb())
            {
                return context.Hotels.Where(x => x.HAID == adminID).ToList();                
            }
        }
    }
}
