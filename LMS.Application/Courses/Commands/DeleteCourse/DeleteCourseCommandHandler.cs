using LMS.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICoursesRepository _coursesRepo;
        private readonly ILogger _logger;
        public DeleteCourseCommandHandler(ICoursesRepository coursesRepo, ILogger logger)
        {
            this._coursesRepo = coursesRepo;
            this._logger = logger;
            
        }
        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("deleting Course ");

            var course = _coursesRepo.GetCourseById(request.id);
            if (course == null)
            {
                return false;
            }

            await _coursesRepo.DeleteCourseAsync(request.id);
            return true;

        }
    }
}
