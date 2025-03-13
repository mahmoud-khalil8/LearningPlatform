using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourseCommandValidator:AbstractValidator<UpdateCourseCommand>
    {
            private readonly List<string> categories = new List<string>
        {
            "Sport",
            "Education",
            "Music",
            "Technology",
            "Health & Fitness",
            "Business",
            "Science",
            "Programming",
            "Mathematics",
            "Art & Design",
            "History",
            "Personal Development",
            "Marketing",
            "Finance",
            "Psychology",
            "Cooking",
            "Language Learning"
        };

        public UpdateCourseCommandValidator()
        {
          

            RuleFor(course => course.title)
                .Length(2, 100)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters and must not be less than 2 characters");

            RuleFor(course => course.Description)
                .NotEmpty().WithMessage("Description is required")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters");

            RuleFor(course => course.InstructorId)
                .NotEmpty().WithMessage("Instructor ID is required");

            RuleFor(course => course.Category)
                .Must(categories.Contains)
                .WithMessage("Invalid Category");
        }
    }
}
