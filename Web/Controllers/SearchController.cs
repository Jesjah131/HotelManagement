using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Web.Models;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        UserRepository rep = new UserRepository();

        [HttpGet]
        public ActionResult Search()
        {
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);


            return PartialView("_SearchFormPartial");
        }

        [HttpPost]
        public ActionResult Search(string hotelName)
        {
            if (hotelName != null)
            {
                try
                {
                    var searchlist = rep.GetSearchedHotels(hotelName);

                    var model = new SearchModel()
                    {
                        Hotels = searchlist
                    };

                    string currUser = System.Web.HttpContext.Current.User.Identity.Name;
                    int userID = UserRepository.GetUserId(currUser);


                    return PartialView("_SearchResultsPartial", model);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return PartialView("Error");
        }
    }
}