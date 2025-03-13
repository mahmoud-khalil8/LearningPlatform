using AutoMapper;
using LMS.Application.Courses.Commands.CreateCourse;
using LMS.Application.Courses.Dtos;
using LMS.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Queries.GetAllCourses
{
    internal class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<CoursesDto>>
    {
        private readonly ILogger<CreateCourseCommand> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepo;

        public GetAllCoursesQueryHandler(ILogger<CreateCourseCommand> logger,
                                          IMapper mapper,
                                          ICoursesRepository coursesRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepo = coursesRepo;
        }
        public async Task<IEnumerable<CoursesDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("getting all courses");
            var courses = await _coursesRepo.getAllCoursesAsync();
            return _mapper.Map<IEnumerable<CoursesDto>>(courses);
        }
    }
}
