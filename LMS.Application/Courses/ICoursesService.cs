using LMS.Application.Courses.Dtos;
using LMS.Domain.Entities;

namespace LMS.Application.Courses
{
    public interface ICoursesService
    {
        Task<IEnumerable<CoursesDto>> getall();
        Task<CoursesDto?> GetCourseById(Guid id);

        Task<CoursesDto> createCourse(CreateCoursesDto courseDto);

    }
}