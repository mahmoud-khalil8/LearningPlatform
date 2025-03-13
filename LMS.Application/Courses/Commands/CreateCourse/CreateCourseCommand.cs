using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.CreateCourse
{
    // it inherit Irequest from mediatr package and take the return type (int)
    public class CreateCourseCommand:IRequest<Guid>
    {
        public string title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; } = default!;
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; } = default!;

        
    }
}
