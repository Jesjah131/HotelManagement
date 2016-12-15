using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data.Repositories;
using Data;
using Web.Models;

namespace Web.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult UserProfile()
        {
            if (CheckPermission())
            {
                return View();
            }
            return RedirectToAction("AdminProfile", "UserProfile");
        }

        public ActionResult AdminProfile()
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

        public bool CheckPermission()
        {
            var rep = new Data.UserRepository();

            var checkIfUser = rep.CheckIfAdminOrNot(User.Identity.Name);

            if(checkIfUser == true)
            {
                return true;
            }
            return false;
        }
    }
}