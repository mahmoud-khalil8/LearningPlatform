using LMS.Application.Courses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Queries.GetCourseById
{
    public class GetCourseByIdQuery:IRequest<CoursesDto>
    {
        public Guid id { get; }
        public GetCourseByIdQuery(Guid _id)
        {
            this.id = _id;
            
        }
    }
}
