using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        [Required]
        [EmailAddress]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = default!;
        [Required]
        [MinLength(6)]
        public string Password { get; set; } = default!;
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = default!;
        [Required]
        [Phone]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$",
            ErrorMessage = "Invalid phone number. Use E.164 format (e.g., +123456789).")] // ✅ Custom Regex for phone validation
        public string phone { get; set; } = default!;


        public List<Course> Courses { get; set; } = new List<Course>();
    
    }
}
