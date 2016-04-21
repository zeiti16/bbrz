using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;
using bbrz_projekt.Data;

namespace bbrz_projekt.ViewModels
{
    public static class Verify
    {

        private static igdbDB db = new igdbDB();

        static Regex ValidEmailRegex = CreateValidEmailRegex();

            private static Regex CreateValidEmailRegex()
            {
                string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                    + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

                return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
            }

            internal static bool EmailIsValid(string emailAddress)
            {
                bool isValid = ValidEmailRegex.IsMatch(emailAddress);

                return isValid;
            }

            public static string HtmlSpecialCharsFunction(string wert)
            {
            return HttpContext.Current.Server.HtmlEncode(wert);
            }

            public static bool IsUserAdmin(string emailUser)
            {
            if (emailUser != "")
            {
                var y = db.tblUser.Where(x => x.Username == emailUser).SingleOrDefault();
                if (y.Administrator == true)
                {
                    return true;
                }
            }
            return false;
            }
    }

    }
