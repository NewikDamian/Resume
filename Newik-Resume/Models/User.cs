using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace Newik_Resume.Models
{
    public class User
    {
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Email { get; set; }
    }
}
