using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Models
{
    public class StudentCourse
    {
        [Key,Column(Order = 0)]
        public int StudentId { get; set; }
        
        [Key, Column(Order = 1)]
        public int CourseId { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
