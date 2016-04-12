using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bbrz_projekt.ViewModels
{
    public class GameModel : Controller
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Genre { get; set; }
        public int Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public HttpPostedFileWrapper Bild { get; set; }

        private IGDBE connection = new IGDBE();

        public bool AddNewGame(string UserEmail)
        {
            if (this.Title.Length >= 3 && this.Description.Length >= 3)
            {
                if(this.ReleaseDate.ToShortDateString() == new DateTime().ToShortDateString())
                {
                    this.ReleaseDate = DateTime.Now;
                }

                tblGame newGame = new tblGame() { Title = Verify.HtmlSpecialCharsFunction(this.Title), Description = Verify.HtmlSpecialCharsFunction(this.Description), FK_Genre = this.Genre, FK_Publisher = this.Publisher, ReleaseDate = (DateTime)this.ReleaseDate, FK_User = UserEmail, Visible = true};
                connection.tblGame.Add(newGame);
                connection.SaveChanges();

                if (this.Bild.FileName != null)
                {
                    tblGame readID = (tblGame)connection.tblGame.Where(x => x.Title == this.Title).SingleOrDefault();

                    if (readID != null)
                    {
                        using (var streamreader = new MemoryStream())
                        {
                            this.Bild.InputStream.CopyTo(streamreader);
                            tblImage newImage = new tblImage() { FK_Game = readID.Game_ID, ImageData = streamreader.ToArray() };
                            connection.tblImage.Add(newImage);
                            connection.SaveChanges();
                            return true;
                        }
                    }
                } else
                {
                    return true;
                }
            }
            return false;

        }
    }
}