using AutoMapper;
using LMS.Application.Courses.Commands.CreateCourse;
using LMS.Application.Courses.Dtos;
using LMS.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CoursesDto>
    {
        private readonly ILogger<CreateCourseCommand> _logger;
        private readonly IMapper _mapper;
        private readonly ICoursesRepository _coursesRepo;

        public GetCourseByIdQueryHandler(ILogger<CreateCourseCommand> logger,
                                          IMapper mapper,
                                          ICoursesRepository coursesRepo)
        {
            _logger = logger;
            _mapper = mapper;
            _coursesRepo = coursesRepo;
        }
        public async Task<CoursesDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("getting one courses with id " + request.id);
            var course = await _coursesRepo.GetCourseById(request.id);

            if (course == null)
            {
                _logger.LogWarning($"Course with ID {request.id} not found");
                return null;
            }
            return _mapper.Map<CoursesDto>(course);
        }
    }
}
