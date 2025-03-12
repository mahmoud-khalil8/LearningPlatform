using LMS.Application.Courses;
using LMS.Application.Courses.Dtos;
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
        [HttpPost]
        public async Task<IActionResult> createCourse([FromBody] CreateCoursesDto courseDto)
        {
            if(courseDto == null)
            {
                return BadRequest("course data is required");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var createdCourse = await ICoursesService.createCourse(courseDto);
            

            return CreatedAtAction(nameof(getCourseById), new { id = createdCourse.Id }, createdCourse);

        }

       
    }
}
