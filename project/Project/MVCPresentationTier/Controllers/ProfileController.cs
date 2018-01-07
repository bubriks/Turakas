using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCPresentationTier.ProfileServiceReference;

namespace MVCPresentationTier.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult LogIn()
        {
            if (Request.Cookies.Get("aCookie") == null)
            {
                ViewBag.LoginStatus = -1;
                return View();
            }
            else
            {
                return Redirect("/");
            }
        }
        
        [HttpPost]
        public ActionResult LogIn(FormCollection collection)
        {
            ProfileServiceClient client = new ProfileServiceClient();
            var username = collection["username"];
            var password = collection["password"];
            Profile profile = new Profile
            {
                Username = username,
                Password = password
            };
            var profileId = client.Authenticate(profile);
            ViewBag.LoginStatus = profileId;
            var cookie = new HttpCookie("aCookie")
            {
                Value = profileId.ToString()
            };
            //var cookieValue = Request.Cookies.Get("aCookie").Value;
            Response.Cookies.Add(cookie);
            return Redirect("/Chat/GetChats");
        }

        [HttpGet]
        public ActionResult CreateProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(FormCollection collection)
        {
            var nickname = collection["nickname"];
            var username = collection["username"];
            var email = collection["email"];
            ProfileServiceClient client = new ProfileServiceClient();
            Profile profile = new Profile
            {
                Username = username,
                Nickname = nickname,
                Email = email,
            };
            int i = client.CreateProfile(profile);
            ViewBag.i = i;
            return View();
        }

        [HttpPost]
        public ActionResult LogOut()
        {
            var cookie = Request.Cookies.Get("aCookie");
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMilliseconds(-1);
                Response.Cookies.Add(cookie);
            }
            return Redirect("/profile/login");
        }
    }
}