using LMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Infrastructure.Persistence
{
    public class LMSDBContext(DbContextOptions<LMSDBContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasOne(c => c.Instructor).WithMany(u => u.Courses).HasForeignKey(c => c.InstructorId);
        }

    }
}
