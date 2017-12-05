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
            ViewBag.LoginStatus = -1;
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(String username, String password)
        {
            ProfileServiceClient client = new ProfileServiceClient();
            Profile profile = new Profile();
            profile.Username = username;
            profile.Password = password;
            ViewBag.LoginStatus = client.Authenticate(profile);
            return View();
        }
        [HttpGet]
        public ActionResult CreateProfile(String username, String nickname, String email, String password)
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(FormCollection collection)
        {
            var nickname = collection["nickname"];
            var username = collection["username"];
            var email = collection["email"];
            var password = collection["password"];
            ProfileServiceClient client = new ProfileServiceClient();
            int i = client.CreateProfileWithInputs(username, nickname, email, password);
            ViewBag.i = i;
            return View();
        }
    }
}