using AutoMapper;
using LMS.Application.Courses.Commands.CreateCourse;
using LMS.Application.Courses.Commands.UpdateCourse;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Dtos
{
    public class CoursesProfile:Profile
    {
        public CoursesProfile()
        {
            //<Source,Destination>
            CreateMap<Course, CoursesDto>().ForMember(dest => dest.InstructorName,
                opt => opt.MapFrom(src => src.Instructor != null ? src.Instructor.Name : "unkonwn"));
            CreateMap<CreateCourseCommand, Course>();
            CreateMap<UpdateCourseCommand, Course>();
        }

    }
}
