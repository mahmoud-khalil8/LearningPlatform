using AutoMapper;
using LMS.Application.Courses.Dtos;
using LMS.Domain.Entities;
using LMS.Domain.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
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
        private readonly IMapper _mapper;
        public CoursesService(ICoursesRepository IRepo , ILogger<CoursesService> logger,IMapper mapper )
        {
            ICoursesRepo = IRepo;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CoursesDto>> getall()
        {
            _logger.LogInformation("getting all courses");
            var courses = await ICoursesRepo.getAllCoursesAsync();
            return _mapper.Map<IEnumerable<CoursesDto>>(courses);
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
            return _mapper.Map<CoursesDto>(course);

        }
        public async Task<CoursesDto> createCourse(CreateCoursesDto courseDto)
        {
            _logger.LogInformation("creating course" );

            var course = _mapper.Map<Course>(courseDto);

            course.Id = Guid.NewGuid();
            course.CreatedAt = DateTime.UtcNow; ;
            
            
            
            var createdCourse = await ICoursesRepo.createCourse(course);



            return _mapper.Map<CoursesDto>(createdCourse);
          



        }
    }
}
