using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public Guid InstructorId { get; set; }
        public User Instructor { get; set; } = default!;
    }
}
