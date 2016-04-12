using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace bbrz_projekt.ViewModels
{
    public class UserModel
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string angemeldetBleiben { get; set; }
        public string Pass_confirmation { get; set; }
        public string Pass { get; set; }
        public bool Gesperrt { get; set; }

        private IGDBE connection = new IGDBE();

        public bool CheckUserEmailPasswort()
        {
            string pw = Hash.CreateSHAHash(this.Password);
            tblUser AktiveUser = connection.tblUser.Where(x => x.Username == this.Email && x.Password == pw && x.Gesperrt != true).SingleOrDefault();
            return AktiveUser != null;
        }
        public bool AddNewUser()
        {
            if (this.Vorname != null && this.Nachname != null && this.Password.Length >= 5 && Verify.EmailIsValid(this.Email))
            {
                var obj = connection.tblUser.FirstOrDefault(x => x.Username == this.Email);
                if (obj == null)
                {
                    tblUser newUser = new tblUser() { Firstname = Verify.HtmlSpecialCharsFunction(this.Vorname), Lastname = Verify.HtmlSpecialCharsFunction(this.Nachname), Password = Hash.CreateSHAHash(this.Password), Username = Verify.HtmlSpecialCharsFunction(this.Email), Administrator = false, Gesperrt = false};
                    connection.tblUser.Add(newUser);
                    connection.SaveChanges();
                    return true;
                }
            }
            return false;
            
        }
        public bool ChangeUser(string user)
        {
            if(this.Vorname != null && this.Nachname != null)
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
        public bool ChangePasswort(string user)
        {
            if (this.Password.Length >= 5 && this.Pass.Length >= 5 && this.Pass_confirmation.Length >= 5 && this.Pass == this.Pass_confirmation)
            {
                tblUser AktiverUser = connection.tblUser.Where(x => x.Username == user).SingleOrDefault();
                if (AktiverUser != null)
                {
                    AktiverUser.Firstname = Hash.CreateSHAHash(this.Pass);
                    connection.SaveChanges();
                    return true;
                }
            }
            return false;

        }
    }

}