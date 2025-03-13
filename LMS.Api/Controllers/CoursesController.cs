using LMS.Application.Courses;
using LMS.Application.Courses.Commands.CreateCourse;
using LMS.Application.Courses.Commands.DeleteCourse;
using LMS.Application.Courses.Commands.UpdateCourse;
using LMS.Application.Courses.Dtos;
using LMS.Application.Courses.Queries.GetAllCourses;
using LMS.Application.Courses.Queries.GetCourseById;
using LMS.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LMS.Api.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        //private readonly ICoursesService ICoursesService;
        private readonly IMediator mediator;
        public CoursesController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var courses = await mediator.Send(new GetAllCoursesQuery());
            return Ok(courses); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getCourseById(Guid id)
        {
            var course = await mediator.Send(new GetCourseByIdQuery(id) );
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpPost]
        public async Task<IActionResult> createCourse([FromBody] CreateCourseCommand command)
        {
            if(command == null)
            {
                return BadRequest("course data is required");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            
            Guid id = await mediator.Send(command);
            

            return CreatedAtAction(nameof(getCourseById), new { id = id }, command);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse([FromRoute] Guid id)
        {
            var result = await mediator.Send(new DeleteCourseCommand(id));
            if (!result)
            {
                return NotFound($"Course with ID {id} not found.");
            }

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            if (command == null)
            {
                return BadRequest("course data is required");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }

            Guid updateCourseId = await mediator.Send(command);
            if (updateCourseId==Guid.Empty)
            {
                return NotFound($"Course with this ID not found.");
            }

            return CreatedAtAction(nameof(getCourseById), new { id = updateCourseId }, command);

        }

    }
}
