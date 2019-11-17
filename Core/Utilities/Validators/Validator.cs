using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Core.Utilities.Validators
{
    public static class Validator
    {
        public static bool ValidateMail(string mail)
        {
            string email = mail;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;

        }

    }
}