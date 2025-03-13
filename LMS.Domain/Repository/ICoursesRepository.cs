using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Repository
{
    public interface ICoursesRepository
    {
         Task<IEnumerable<Course>> getAllCoursesAsync();
         Task<Course?> GetCourseById(Guid id);
        Task<Course> createCourse( Course course);
        Task<Course> UpdateCourse( Course course);
        Task DeleteCourseAsync(Guid id);
        Task saveChangesAsync();



    }
}
