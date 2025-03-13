using AutoMapper;
using LMS.Application.Courses.Dtos;
using LMS.Domain.Entities;
using LMS.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.CreateCourse
{
    //it inherit IRequestHandler from Mediatr and take the Create command and the return type of that command
    public class CreateCourseCommandHandler: IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ILogger<CreateCourseCommand> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepo;

        public CreateCourseCommandHandler(ILogger<CreateCourseCommand> logger,
                                          IMapper mapper,
                                          ICoursesRepository coursesRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepo = coursesRepo;
        }
        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("creating course");

           
            var course = _mapper.Map<Course>(request);

            course.Id = Guid.NewGuid();
            course.CreatedAt = DateTime.UtcNow; ;



            var createdCourse = await _coursesRepo.createCourse(course);



            return createdCourse.Id;




        }
    }
}
