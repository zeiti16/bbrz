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
        private IGDBEntities connection = new IGDBEntities();

        // GET: MySpace
        [Authorize]
        public ActionResult MeinProfil()
        {
            var AktiveUser = connection.tblUser.Where(x => x.Username == User.Identity.Name).SingleOrDefault();
            if(AktiveUser != null)
            {
                return View(new LoginData() { Vorname = AktiveUser.Firstname, Nachname = AktiveUser.Lastname, Email = AktiveUser.Username });
            } else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult ChangeUserData(LoginData data)
        {
            if (data.ChangeUser(User.Identity.Name))
            {
                return RedirectToAction("MeinProfil", "MySpace", new { result = true });
            }
            else
                return RedirectToAction("MeinProfil", "MySpace", new { result = false });
        }
    }
}