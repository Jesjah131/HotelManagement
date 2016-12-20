using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.IO;
using Data;

namespace Web.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file, int hotelId)
        {
            string userName = System.Web.HttpContext.Current.User.Identity.Name;
            int userID = UserRepository.GetUserId(userName);

            if (!Directory.Exists(Server.MapPath("~/Images")))
            {
                Directory.CreateDirectory(Server.MapPath("~/Images"));
            }
            try
            {
                string filename = System.IO.Path.GetFileName(file.FileName);

                file.SaveAs(Server.MapPath("~/Images/" + filename));

                var path = (Server.MapPath("~/Images/" + filename));

                UserRepository save = new UserRepository();

                save.ChangeImage(filename, hotelId);

                ViewBag.Message = "Successfully uploaded picture to: " + path;
            }
            catch
            {
                ViewBag.Message = "Failed to upload picture!";
            }
            return View();
        }
    }
}