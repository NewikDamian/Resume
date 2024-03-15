using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using Newik_Resume.Models;
using Newik_Resume.Data;

namespace Newik_Resume.Transformer
{
    public static class ToUserModelTransformer
    {
        public static User? ToUserModel(this JsonUser jsonUser)
        {
            if (jsonUser != null && jsonUser.ValidateData())
            {
                List<string> exp = new List<string>();
                if (jsonUser.Exp != null)
                {
                    exp.AddRange(jsonUser.Exp);
                }

                List<string> some = new List<string>();
                if (jsonUser.SomeExp != null)
                {
                    some.AddRange(jsonUser.SomeExp);
                }

                List<string> other = new List<string>();
                if (jsonUser.Other != null)
                {
                    other.AddRange(jsonUser.Other);
                }

                List<string> lang = new List<string>();
                if (jsonUser.Languages != null)
                {
                    lang.AddRange(jsonUser.Languages);
                }

                List<WorkExperience> workExperiences = new List<WorkExperience>();
                if (jsonUser.RelevantWorkExperience != null && jsonUser.RelevantWorkExperience.Length > 0)
                {
                    for (int i = 0; i < jsonUser.RelevantWorkExperience.Length; i++)
                    {
                        workExperiences.Add(jsonUser.RelevantWorkExperience[i].ToWorkExperienceModel());
                    }
                }

                List<Education> education = new List<Education>();
                if (jsonUser.Education != null && jsonUser.Education.Length > 0)
                {
                    for (int i = 0; i < jsonUser.Education.Length; i++)
                    {
                        education.Add(jsonUser.Education[i].ToEducationModel());
                    }
                }

#pragma warning disable CS8601 // Possible null reference assignment.
                return new User
                {
                    Name = jsonUser.Name + " " + jsonUser.LastName,
                    Email = jsonUser.Email,
                    Phone = jsonUser.Phone,
                    Exp = exp.ToArray(),
                    SomeExp = some.ToArray(),
                    Other = other.ToArray(),
                    Languages = lang.ToArray(),
                    Profile = jsonUser.Profile,
                    WorkExperiences = workExperiences.ToArray(),
                    About = jsonUser.About,
                    Education = education.ToArray(),
                    Linked = $"<a href=\"{jsonUser.Linked}\">{jsonUser.Linked}</a>",

                    IsValid = true
                };
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            else
            {
                return null;
            }
        }

        public static WorkExperience ToWorkExperienceModel(this JsonWorkExperience jsonWorkExp)
        {
            WorkExperience modelWorkExp = new WorkExperience();

            modelWorkExp.Name = jsonWorkExp.CompanyName;
            if (jsonWorkExp.CurrentJob)
            {
                modelWorkExp.ExpYears = $"{jsonWorkExp.DateFrom.Year} - CURRENT";
            }
            else
            {
                modelWorkExp.ExpYears = $"{jsonWorkExp.DateFrom.Year} - {jsonWorkExp.DateTo.Year}";
            }

            List<Stack> stacks = new List<Stack>();
            if (jsonWorkExp.Stack != null && jsonWorkExp.Stack.Length > 0)
            {
                for (int j = 0; j < jsonWorkExp.Stack.Length; j++)
                {
                    stacks.Add(jsonWorkExp.Stack[j].ToStackModel());
                }
            }
            modelWorkExp.Stack = stacks.ToArray();

            return modelWorkExp;
        }

        public static Stack ToStackModel(this JsonStack jsonStack)
        {
            Stack stack = new Stack();

            stack.Name = jsonStack.TechName;
            stack.Position = jsonStack.Position;

            return stack;
        }

        public static Education ToEducationModel(this JsonEducation jsonEducation)
        {
            Education education = new Education();

            education.Field = jsonEducation.Field == null ? "" : jsonEducation.Field;
            education.Name = jsonEducation.Name == null ? "" : jsonEducation.Name;
            education.Degree = jsonEducation.Degree == null ? "" : jsonEducation.Degree;
            education.DateFrom = jsonEducation.DateFrom;
            education.DateTo = jsonEducation.DateTo;

            return education;
        }
    }
}
