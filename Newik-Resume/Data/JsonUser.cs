using Newik_Resume.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.Numerics;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Newik_Resume.Data
{
    public class JsonUser
    {
        public Guid UserID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public bool ValidateData()
        {
            if (UserID == Guid.Empty)
                return false;

            if (Name == null || Name.Length < 3)
                return false;

            if (LastName == null || LastName.Length < 3)
                return false;

            if (!ValidatePhone(Phone))
            {
                return false;
            }

            if (!ValidateEmail(Email))
                return false;

            return true;
        }

        private bool ValidatePhone(string? phone)
        {
            if (phone == null)
                return false;

            if (Regex.Replace(phone, @"[^0-9]+", "").Length >= 10)
                return true;
            else
                return false;
        }

        private bool ValidateEmail(string? email)
        {
            if (email == null)
                return false;

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
