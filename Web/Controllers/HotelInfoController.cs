using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Web.Models;
using System.Net;
using Data;

namespace Web.Controllers
{
    public class HotelInfoController : Controller
    {
        // GET: HotelInfo
        public ActionResult HotelInfo(int? HotelHID)
        {

            if (HotelHID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rep = new HotelRepository();
            var hotel = new Data.Hotel();
            var rooms = new List<Room>();
            var hotelpic = new Data.HotelPic();
            hotel = rep.GetSpecificHotelInfo(HotelHID);
            rooms = rep.GetAllRoomsFromSpecificHotel(HotelHID);
            hotelpic = rep.GetHotelImage(HotelHID);
            var model = new HotelInfoModel();
            model.HID = hotel.HID;
            model.Hotelname = hotel.Hotelname;
            model.Hotelchain = hotel.Hotelchain;
            model.City = hotel.City;
            model.Streetname = hotel.Streetname;
            model.Country = hotel.Country;
            model.Stars = hotel.Stars;
            model.Description = hotel.Description;
            model.HAID = hotel.HAID;
            model.rooms = rooms;
            if(hotelpic != null)
            { 
            model.Img_path = hotelpic.IMG;
            }
            else
            { 
            model.Img_path = null;
            }

            return View(model);
        }

        public ActionResult ManageHotels(string String)
        {
            HotelAdmin ha = new HotelAdmin();

            var rep = new HotelAdminRepository();

            ha = rep.GetHotelAdminInfo(User.Identity.Name);

            var list = new List<Hotel>();

            list = rep.GetHotelAdminHotels(ha.HAID);

            var model = new AdminProfileModel();

            model.hotelList = list;

            return View(model);
        }

        public void RemoveHotel(int? hotelHID)
        {
            HotelRepository.RemoveSpecificHotel(hotelHID);
        }

        
    }
}