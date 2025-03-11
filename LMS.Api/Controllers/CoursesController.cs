using LMS.Application.Courses;
using LMS.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesService ICoursesService;
        public CoursesController(ICoursesService IService)
        {
            ICoursesService = IService;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var courses = await ICoursesService.getall();
            return Ok(courses); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCourseById(Guid id)
        {
            var course = await ICoursesService.GetCourseById(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

    }
}
