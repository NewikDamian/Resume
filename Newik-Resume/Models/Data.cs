using Newik_Resume.Data;
using Newik_Resume.Transformer;
using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Newik_Resume.Models
{
    public class ResumeData
    {
        public User User { get; private set; }

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

                if (user != null)
                {
                    var userModel = user.ToUserModel();
                    if (userModel != null)
                    {
                        return userModel;
                    }
                }


                return new User
                {
                    Name = "",
                    Email = "",
                    Phone = "",
                    Exp = new string[0],
                    SomeExp = new string[0],
                    Other = new string[0],
                    Languages = new string[0],
                    Profile = "",
                    IsValid = false
                };
            }
        }
    }
}
