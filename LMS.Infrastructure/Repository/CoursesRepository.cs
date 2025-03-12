using LMS.Domain.Entities;
using LMS.Domain.Repository;
using LMS.Infrastructure.Persistence;
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
            await _LMSDBContext.SaveChangesAsync();
            return course;
        }
    }
}
