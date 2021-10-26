using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Models
{
    public class Department
    {
        public Department()
        {
            this.Courses = new HashSet<Course>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
