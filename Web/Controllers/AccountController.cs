using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Models;
using Data.Repositories;
using Data;
using WebMatrix.WebData;
using Web.Controllers;

namespace Web.Controllers
{
  
    public class AccountController : Controller
    {

        public ActionResult Login(UserLoginModel model)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {

                //return View();

                var user = UserRepository.LoginUser(model.Username, model.Password);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("UserProfile", "UserProfile");
                }
                else
                {
                    ModelState.AddModelError("", "Fel på användarnamn eller lösenord.");
                    return View();
                }

            //}


            // If we got this far, something failed, redisplay form

        }
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        public ActionResult CreateNewUser(CreateUserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new Data.User();

            user.Username = model.Username;
            user.Password = model.Password;
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.Email = model.Email;
            user.City = model.City;
            user.Postcode = model.Postcode;
            user.Street = model.Street;

            UserRepository rep = new UserRepository();

            rep.CreateUser(user);
            ModelState.Clear();
            return RedirectToAction("Login", "Account");
        }


        public ActionResult HotelAdminLogin(UserLoginModel model)
        {

            if (ModelState.IsValid)
            {
       
                //return View();
               var admin = new HotelAdminRepository();

                admin.LoginHotelAdmin(model.Username, model.Password);

                if (admin != null)
                {
                    
                   

                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToAction("UserProfile", "UserProfile");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                    return View();
                }
            }
            return View(model);


            // If we got this far, something failed, redisplay form
        }
    }
}