using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Must include Roll Number")]
        public int Roll { get; set; }

        [Required(ErrorMessage = "Must include Student Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
        
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual IEnumerable<StudentCourse> StudentCourses { get; set; }
        public virtual Department Department { get; set; }
    }
}
