using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Data.Repositories;
using Data;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new AllHotelModel();

            model.AllHotels = HotelRepository.GetAllHotels();

            return View(model);
        }
    }
}