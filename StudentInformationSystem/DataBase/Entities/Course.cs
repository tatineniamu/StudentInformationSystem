using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
