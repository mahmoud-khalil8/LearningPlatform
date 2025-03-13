using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourseCommand:IRequest<bool>
    {
        public Guid id { get; }
        public DeleteCourseCommand(Guid _id)
        {
            this.id = _id;
            
        }
    }
}
