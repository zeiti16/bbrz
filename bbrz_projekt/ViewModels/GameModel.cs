using bbrz_projekt.Data;
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
        public int IdGame { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public string TitleGame { get; set; }
        public string Description { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int PublisherId { get; set; }
        public int PublisherName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public HttpPostedFileWrapper Bild { get; set; }
        public int BildId { get; set; }

        private igdbEntity connection = new igdbEntity();

        public bool AddNewGame(string UserEmail)
        {
            if (this.TitleGame.Length >= 3 && this.Description.Length >= 3)
            {
                if(this.ReleaseDate.ToShortDateString() == new DateTime().ToShortDateString())
                {
                    this.ReleaseDate = DateTime.Now;
                }

                tblGame newGame = new tblGame() { Title = Verify.HtmlSpecialCharsFunction(this.TitleGame), Description = Verify.HtmlSpecialCharsFunction(this.Description), FK_Genre = this.GenreId, FK_Publisher = this.PublisherId, ReleaseDate = (DateTime)this.ReleaseDate, FK_User = UserEmail, Visible = true};
                connection.tblGame.Add(newGame);
                connection.SaveChanges();

                try {
                    tblGame readID = (tblGame)connection.tblGame.Where(x => x.Title == this.TitleGame).SingleOrDefault();

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
                } catch
                {
                    return true;
                }
            }
            return false;

        }
    }
}