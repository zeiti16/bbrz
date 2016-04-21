using bbrz_projekt.Data;
using bbrz_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace bbrz_projekt.Controllers
{
    public class HomeController : Controller
    {
        private igdbDB connection = new igdbDB();
        // GET: Home
        public ActionResult Index()
        {
            var elemList = connection.AusgabeNewGame().ToList();
            List<GameModel> NewGamesList = new List<GameModel>();
            foreach (var item in elemList)
            {
               if(item.CountRating == 0)
                {
                    item.UserRating = 0;
                }
                if (item.Image_ID == null)
                {
                    item.Image_ID = 0;
                }
                NewGamesList.Add(new GameModel() { IdGame = item.Game_ID, TitleGame = item.GameTitel, GenreName = item.GenreTitel, Rating = (Double)item.UserRating, RatingCount = (int)item.CountRating, ReleaseDate = Convert.ToDateTime(item.ReleaseDate), BildId = (int)item.Image_ID});
            }
            NewGamesList.Reverse();
            return View(NewGamesList);
        }

    }
}