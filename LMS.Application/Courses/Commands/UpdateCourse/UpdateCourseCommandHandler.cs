using AutoMapper;
using LMS.Application.Courses.Commands.CreateCourse;
using LMS.Domain.Entities;
using LMS.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Guid>
    {
        private readonly ILogger<CreateCourseCommand> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepo;

        public UpdateCourseCommandHandler(ILogger<CreateCourseCommand> logger,
                                          IMapper mapper,
                                          ICoursesRepository coursesRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepo = coursesRepo;
        }
        public async Task<Guid> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("updating course");


            var course = _mapper.Map<Course>(request);

            course.Id = Guid.NewGuid();
            course.CreatedAt = DateTime.UtcNow; ;



            var updatedCourse = await _coursesRepo.UpdateCourse(course);



            return updatedCourse.Id;
        }

        
    }
}
