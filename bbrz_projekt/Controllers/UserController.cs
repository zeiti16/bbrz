using bbrz_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace bbrz_projekt.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(LoginData data)
        {
            //FormsAuthentication.SetAuthCookie(data.Email, true);
            //return RedirectToAction("Index", "Home");
            if (data.CheckUserEmailPasswort())
            {
                if (data.angemeldetBleiben == "true")
                    FormsAuthentication.SetAuthCookie(data.Email, true);
                else
                    FormsAuthentication.SetAuthCookie(data.Email, false);
                return Content("true");
            } else
            {
                return Content("false");
            }
 
        }

        [HttpPost]
        public ActionResult Registrierung(LoginData data)
        {

            if (data.AddNewUser())
            {
                FormsAuthentication.SetAuthCookie(data.Email, true);
                return Content("true");
            }
            else
                return Content("false");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}