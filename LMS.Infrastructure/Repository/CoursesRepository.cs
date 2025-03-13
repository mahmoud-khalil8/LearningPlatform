using LMS.Domain.Entities;
using LMS.Domain.Repository;
using LMS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Repository
{
    public class CoursesRepository:ICoursesRepository
    {
        private readonly LMSDBContext _LMSDBContext;
        public CoursesRepository(LMSDBContext dbcontext )
        {
            _LMSDBContext = dbcontext ?? throw new ArgumentNullException(nameof(LMSDBContext));
            
        }

        public async Task<IEnumerable<Course>> getAllCoursesAsync()
        {
            return await _LMSDBContext.Courses.Include(c=>c.Instructor).ToListAsync();
        }
        public async Task<Course?> GetCourseById(Guid id)
        {
            return await _LMSDBContext.Courses.Include(c=>c.Instructor)
                .SingleOrDefaultAsync(c=>c.Id==id);
        }
        public async Task<Course> createCourse(Course course)
        {
            
            await _LMSDBContext.AddAsync(course);
            await saveChangesAsync();
            return course;
        }

        public async Task DeleteCourseAsync(Guid id)
        {
            var course = await _LMSDBContext.Courses.FindAsync(id);

            if (course != null)
            {
                _LMSDBContext.Courses.Remove(course);
                await saveChangesAsync();
            }
           
            
        }

        public async Task<Course?> UpdateCourse(Course course)
        {

            var Existingcourse = await _LMSDBContext.Courses.FindAsync(course.Id);

            if (Existingcourse == null)
            {
                return null;
            }

            Existingcourse.title = course.title;
            Existingcourse.CreatedAt = course.CreatedAt;
            Existingcourse.Description = course.Description;
            Existingcourse.Category = course.Category;
            Existingcourse.InstructorId = course.InstructorId;

            await saveChangesAsync();
            return Existingcourse;
        }

        public async Task saveChangesAsync()
        {
            await _LMSDBContext.SaveChangesAsync();
        }
    }
}
