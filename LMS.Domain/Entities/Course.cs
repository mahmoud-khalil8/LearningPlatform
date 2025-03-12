using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        [Required]
        public string title { get; set; } = default!;
        [Required]
        [MaxLength(500)]
        [MinLength(10)]
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; } = default!;

        [Required]
        public Guid InstructorId { get; set; }
        public User Instructor { get; set; } = default!;
    }
}
