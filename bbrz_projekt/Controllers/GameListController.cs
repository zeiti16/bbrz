using bbrz_projekt.Data;
using bbrz_projekt.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bbrz_projekt.Controllers
{
    public class GameListController : Controller
    {
        private igdbDB db = new igdbDB();

        // GET: GameList
        public ActionResult Index(string searchGame)
        {
            ViewBag.Genre = db.tblGenre.ToList();
            ViewBag.GameName = Verify.HtmlSpecialCharsFunction(searchGame);
            return View();
        }

        [HttpPost]
        public string SearchEntries(string searchName, int genreId, int minRating, int page)
        {
            List<LadeGamesListe_Result> x = db.LadeGamesListe(page, Verify.HtmlSpecialCharsFunction(searchName),genreId,minRating).ToList();

            string output = "";
            for (int i = 0; i < x.Count; i++)
            {

                output += "<div class='col-sm-4 col-md-3'>" +
                    "<div class='thumbnail'><div class='thumbTitle'>" + x[i].GenreTitel + "</div>" +
                        "<div class='rounded-skill thumbRatingRound' data-color='#e74c3c' data-trackcolor='rgba(0,0,0,0.1)' data-size='55' data-percent='" + (x[i].UserRating * 20) + "' data-width='4' data-animate='3000'>" + x[i].UserRating + "</div>" +
                        "<div class='thumbVoits'>" + x[i].CountRating + " Votes</div>";
                        if (x[i].Image_ID != null)
                        {
                            output += "<img class='thumbImage' data-src='holder.js/300x200' alt='300x200' src='data:image/jpeg;base64," + Convert.ToBase64String(Base64ToImage((int)x[i].Image_ID)) + "'>";
                        } else
                        {
                            output += "<img class='thumbImage' data-src='holder.js/300x200' alt='300x200' src='../../Images/noImage.jpg' />";
                        }
                        output += "<div class='caption'>"+
                        "<h3 class='nobottommargin'>"+x[i].GameTitel+"</h3>"+
                        "<p>Release: "+String.Format("{0:MM-yyyy}", x[i].ReleaseDate) + "</p>"+
                        "<a href = '#' class='btn btn-default' role='button'>zur Detailseite</a>"+
                        "</div></div></div>";
            }
            return output;
        }


        public byte[] Base64ToImage(int id)
        {
            var img = db.tblImage.Where(x => x.Image_ID == id).SingleOrDefault();
            return img.ImageData;
        }
    }
}