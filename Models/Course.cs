using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Models
{
    public class Course
    {
        public Course()
        {
            this.Departments = new HashSet<Department>();
        }
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<StudentCourse> StudentCourses { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
