using Newik_Resume.Data;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Newik_Resume.Models
{
    public class ResumeData
    {
        public User User { get; private set; }

        public bool IsValid { get; private set; }

        public ResumeData()
        {
            User = LoadUser();
        }

        private User LoadUser()
        {
            using (StreamReader r = new StreamReader("Data/User.json"))
            {
                string json = r.ReadToEnd();
                JsonUser? user = JsonConvert.DeserializeObject<JsonUser>(json);

                if (user != null && user.ValidateData())
                {
                    IsValid = IsValid && true;

                    List<string> exp = new List<string>();
                    if (user.Exp != null)
                    {
                        exp.AddRange(user.Exp);
                    }

                    List<string> some = new List<string>();
                    if (user.SomeExp != null)
                    {
                        some.AddRange(user.SomeExp);
                    }

                    List<string> other = new List<string>();
                    if (user.Other != null)
                    {
                        other.AddRange(user.Other);
                    }

                    List<string> lang = new List<string>();
                    if (user.Languages != null)
                    {
                        lang.AddRange(user.Languages);
                    }

#pragma warning disable CS8601 // Possible null reference assignment.
                    return new User
                    {
                        Name = user.Name + " " + user.LastName,
                        Email = user.Email,
                        Phone = user.Phone,
                        Exp = exp.ToArray(),
                        SomeExp = some.ToArray(),
                        Other = other.ToArray(), 
                        Languages = lang.ToArray(), 
                        Profile = user.Profile,
                    };
#pragma warning restore CS8601 // Possible null reference assignment.
                }
                else
                {
                    IsValid = false;
                    return new User
                    {
                        Name = "",
                        Email = "",
                        Phone = "",
                        Exp = new string[0],
                        SomeExp = new string[0],
                        Other = new string[0],
                        Languages = new string[0],
                        Profile = ""
                    };
                }
            }
        }
    }
}
