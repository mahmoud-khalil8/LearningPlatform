using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Dtos
{
    public class CoursesDto
    {
        public Guid Id { get; set; }
        public string title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public string Category { get; set; } = default!;
        public Guid InstructorId { get; set; }
        public string InstructorName { get; set; } = default!;


        public static CoursesDto FromEntity(Course course)
        {
            return new CoursesDto
            {
                Id = course.Id,
                title = course.title,
                Description = course.Description,
                InstructorId = course.InstructorId,
                InstructorName = course.Instructor?.Name ?? "unknown",
                CreatedAt = course.CreatedAt,
            };

        }
    }

}
