using LMS.Application.Courses.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Queries.GetAllCourses
{
    public class GetAllCoursesQuery:IRequest<IEnumerable<CoursesDto>>
    {


    }
}
