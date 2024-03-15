using Newik_Resume.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.Numerics;
using Microsoft.AspNetCore.Http.HttpResults;
using System;

namespace Newik_Resume.Data
{
    public class JsonUser
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string[]? Exp {  get; set; }
        public string[]? SomeExp { get; set; }
        public string[]? Other { get; set; }
        public string[]? Languages { get; set; }
        public string Profile { get; set; } = "";
        public JsonWorkExperience[] RelevantWorkExperience { get; set; } = new JsonWorkExperience[0];
        public string About { get; set; } = "";
        public JsonEducation[] Education { get; set; } = new JsonEducation[0];
        public string Linked { get; set; } = "";


        public bool ValidateData()
        {
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

    public class JsonWorkExperience
    {
        public required string CompanyName { get; set; }
        public required DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public bool CurrentJob { get; set; }
        public required JsonStack[] Stack { get; set; }
    }

    public class JsonStack
    {
        public required string TechName { get; set; }
        public required string Position { get; set; }
        public string[] Descriptions { get; set; } = new string[0];
    }

    public class JsonEducation
    {
        public string? Name { get; set; }
        public string? Degree { get; set; }
        public string? Field { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
