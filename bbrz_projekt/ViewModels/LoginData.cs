using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            if (AktiveUser != null)
                return true;
            return false;
        }
        public bool AddNewUser()
        {
            if (this.Vorname != null && this.Nachname != null && this.Password.Length >= 5 && EmailVerify.EmailIsValid(this.Email))
            {
                tblUser newUser = new tblUser() { Firstname = this.Vorname, Lastname = this.Nachname, Password = Hash.CreateSHAHash(this.Password), Username = this.Email, Administrator = false };
                connection.tblUser.Add(newUser);
                connection.SaveChanges();
                return true;
            }
            else
                return false;
            
        }
    }

}