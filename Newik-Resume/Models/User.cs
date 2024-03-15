using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Newik_Resume.Models
{
    public class User
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
        public string[] Exp { get; set; } = new string[0];
        public string[] SomeExp { get; set; } = new string[0];
        public string[] Other { get; set; } = new string[0];
        public string[] Languages { get; set; } = new string[0];
        public string Profile { get; set; } = "";
        public WorkExperience[] WorkExperiences { get; set; } = new WorkExperience[0];
        public string About { get; set; } = "";
        public Education[] Education { get; set; } = new Education[0];
        public string Linked { get; set; } = "";

        public bool IsValid { get; set; } = false;
    }

    public class WorkExperience
    {
        public string? Name { get; set; }
        public string? ExpYears { get; set; }
        public Stack[] Stack { get; set; } = new Stack[0];
    }

    public class Stack
    {
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string[] Descriptions { get; set; } = new string[0];
    }

    public class Education
    {
        public string Name { get; set; } = "";
        public string Degree { get; set; } = "";
        public string Field { get; set; } = "";
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
