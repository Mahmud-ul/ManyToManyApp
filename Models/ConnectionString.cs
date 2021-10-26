using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Models
{
    public class ConnectionString:DbContext
    {
        public ConnectionString(DbContextOptions<ConnectionString> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<StudentCourse>().HasKey(s => new { s.StudentId, s.CourseId });
            model.Entity<Student>().HasIndex(s => s.Roll).IsUnique();
            //base.OnModelCreating(model);
        }
    }
}
