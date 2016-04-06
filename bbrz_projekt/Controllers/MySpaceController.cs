using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bbrz_projekt.Controllers
{
    public class MySpaceController : Controller
    {
        // GET: MySpace
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}