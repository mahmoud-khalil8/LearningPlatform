using LMS.Application.Courses.Dtos;
using LMS.Domain.Entities;
using LMS.Domain.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses
{
    public class CoursesService : ICoursesService
    {
        private readonly ICoursesRepository ICoursesRepo;
        private readonly ILogger _logger;
        public CoursesService(ICoursesRepository IRepo , ILogger logger )
        {
            ICoursesRepo = IRepo;
            _logger = logger;

        }

        public async Task<IEnumerable<CoursesDto>> getall()
        {
            _logger.LogInformation("getting all courses");
            var courses = await ICoursesRepo.getAllCoursesAsync();
            return courses.Select(course => CoursesDto.FromEntity(course)).ToList();
        }
        public async Task<CoursesDto?> GetCourseById(Guid id)
        {
            _logger.LogInformation("getting one courses with id " + id);
            var course =  await ICoursesRepo.GetCourseById(id);

            if (course == null)
            {
                _logger.LogWarning($"Course with ID {id} not found");
                return null;
            }
            return CoursesDto.FromEntity(course);

        }
    }
}
