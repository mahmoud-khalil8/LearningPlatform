using LMS.Domain.Entities;
using LMS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Seeders
{
    public class LMSSeeder : ILMSSeeder
    {
        public async Task Seed(LMSDBContext dbContext)
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.Users.Any())
                {
                    var users = LoadUsers();
                    await dbContext.Users.AddRangeAsync(users);
                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Courses.Any())
                {
                    var blogs = LoadCourses(dbContext);
                    await dbContext.Courses.AddRangeAsync(blogs);
                    await dbContext.SaveChangesAsync();
                }
            }
        }
        public List<User> LoadUsers()
        {
            return new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    Password = "hashed_password_1",
                    Role = "Instructor",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob Smith",
                    Email = "bob.smith@example.com",
                    Password = "hashed_password_2",
                    Role = "Student",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "Charlie Davis",
                    Email = "charlie.davis@example.com",
                    Password = "hashed_password_3",
                    Role = "Instructor",
                }
            };
        }

        public List<Course> LoadCourses(LMSDBContext dbContext)
        {
            var instructors = dbContext.Users.Where(u => u.Role == "Instructor").ToList();

            if (!instructors.Any()) return new List<Course>();

            return new List<Course>
            {
                new Course
                {
                    Id = Guid.NewGuid(),
                    title = "Introduction to C#",
                    Description = "Learn the basics of C# programming.",
                    CreatedAt = DateTime.UtcNow,
                    InstructorId = instructors[0].Id
                },
                new Course
                {
                    Id = Guid.NewGuid(),
                    title = "Advanced .NET Development",
                    Description = "Explore advanced topics in .NET Core.",
                    CreatedAt = DateTime.UtcNow,
                    InstructorId = instructors.Count > 1 ? instructors[1].Id : instructors[0].Id
                }
            };

        }
    }
}
