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
#pragma warning disable CS8601 // Possible null reference assignment.
                    return new User
                    {
                        Name = user.Name + " " + user.LastName,
                        Email = user.Email,
                        Phone = user.Phone
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
                        Phone = ""
                    };
                }
            }
        }
    }
}
