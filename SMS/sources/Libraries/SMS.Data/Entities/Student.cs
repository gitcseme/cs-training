using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SMS.Data.Entities
{
    public class Student : EntityBase<Guid>
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string Standard { get; set; }
        public string PhotoPath { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
    }
}
