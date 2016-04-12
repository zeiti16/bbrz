using bbrz_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bbrz_projekt.Controllers
{
    public class MySpaceController : Controller
    {
        private IGDBE connection = new IGDBE();

        // GET: MySpace
        [Authorize]
        public ActionResult MeinProfil()
        {
            var AktiveUser = connection.tblUser.Where(x => x.Username == User.Identity.Name).SingleOrDefault();
            if(AktiveUser != null)
            {
                return View(new UserModel() { Vorname = AktiveUser.Firstname, Nachname = AktiveUser.Lastname, Email = AktiveUser.Username });
            } else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public ActionResult MeinPasswort()
        {
            return View();
        }

        [Authorize]
        public ActionResult SpielAnlegen()
        {
            ViewBag.Genre = connection.tblGenre.ToList();
            ViewBag.Publisher = connection.tblPublisher.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult ChangeUserData(UserModel data)
        {
            if (data.ChangeUser(User.Identity.Name))
            {
                return RedirectToAction("MeinProfil", "MySpace", new { result = true });
            }
            else
                return RedirectToAction("MeinProfil", "MySpace", new { result = false });
        }

        [HttpPost]
        public ActionResult AddNewGame(GameModel data)
        {
            if (data.AddNewGame(User.Identity.Name))
            {
                return RedirectToAction("SpielAnlegen", "MySpace", new { result = true });
            }
            else
            {
                return RedirectToAction("SpielAnlegen", "MySpace", new { result = false });
            }
            
        }

        [HttpPost]
        public ActionResult ChangeUserPw(UserModel data)
        {
            if (data.ChangePasswort(User.Identity.Name))
            {
                return RedirectToAction("MeinPasswort", "MySpace", new { result = true });
            }
            else
                return RedirectToAction("MeinPasswort", "MySpace", new { result = false });
        }
    }
}