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
    }
}
