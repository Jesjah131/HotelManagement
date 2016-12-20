using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Data
{
    public class UserRepository
    {

        public static User LoginUser(string username, string password)
        {
            using (var context = new Hoteldb())
            {
                return context.Users.FirstOrDefault(x =>
                    x.Username.Equals(username) &&
                    x.Password.Equals(password));
                //hi
            }
        }

        public void CreateUser(User user)
        {

            using (var context = new Hoteldb())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool CheckIfAdminOrNot(string username)
        {
            using (var context = new Hoteldb())
            {
               var hej = context.Users.FirstOrDefault(x => x.Username.Equals(username));

               if (hej != null)
               {
                   return true;
               }
               
            }
            return false;            
        }

        public List<Hotel> GetSearchedHotels(string query)
        {
            Hoteldb db = new Hoteldb();

            var queryz = db.Hotels.Where(x => x.Hotelname.Contains(query));

            return queryz.ToList();
        }

        public static int GetUserId(string username)
        {
            using (var context = new Hoteldb())
            {
                var result = context.Users.FirstOrDefault(x => x.Username == username);

                return result != null ? result.UID : -1;
            }
        }

        public static bool DoUserNameExists(string Username)
        {
            Hoteldb db = new Hoteldb();

            var userexists = db.Users.Count(x => x.Username == Username);
            if (userexists == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeImage(string imgpath, int hid)
        {
            try
            {
                using (var context = new Hoteldb())
                {
                    HotelPic hotelpic = context.HotelPics.FirstOrDefault(x => x.HID == hid);

                    if(hotelpic == null) { 
                    HotelPic pic = new HotelPic();

                    pic.IMG = imgpath;
                    pic.HID = hid;

                    context.HotelPics.Add(pic);
                        context.SaveChanges();
                    }
                    else
                    {
                        hotelpic.IMG = imgpath;
                        context.SaveChanges();
                    }
                   
                }
            }
            catch
            {
                //Eventuellt felmeddelande
            }
        }
    }
}
