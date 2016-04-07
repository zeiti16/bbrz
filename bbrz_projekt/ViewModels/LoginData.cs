using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace bbrz_projekt.ViewModels
{
    public class LoginData
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string angemeldetBleiben { get; set; }

        private IGDBEntities connection = new IGDBEntities();

        public bool CheckUserEmailPasswort()
        {
            string pw = Hash.CreateSHAHash(this.Password);
            tblUser AktiveUser = connection.tblUser.Where(x => x.Username == this.Email && x.Password == pw).SingleOrDefault();
            return AktiveUser != null;
        }
        public bool AddNewUser()
        {
            if (this.Vorname != null && this.Nachname != null && this.Password.Length >= 5 && Verify.EmailIsValid(this.Email))
            {
                tblUser newUser = new tblUser() { Firstname = Verify.HtmlSpecialCharsFunction(this.Vorname), Lastname = Verify.HtmlSpecialCharsFunction(this.Nachname), Password = Hash.CreateSHAHash(this.Password), Username = Verify.HtmlSpecialCharsFunction(this.Email), Administrator = false };
                connection.tblUser.Add(newUser);
                connection.SaveChanges();
                return true;
            }
            else
                return false;
            
        }
        public bool ChangeUser(string user)
        {
            if(this.Vorname.Length >= 1 && this.Nachname.Length >= 1)
            {
                tblUser AktiverUser = connection.tblUser.Where(x => x.Username == user).SingleOrDefault();
                if(AktiverUser != null) {
                    AktiverUser.Firstname = Verify.HtmlSpecialCharsFunction(this.Vorname);
                    AktiverUser.Lastname = Verify.HtmlSpecialCharsFunction(this.Nachname);
                    connection.SaveChanges();
                    return true;
                }
            }
            return false;
            
        }
    }

}