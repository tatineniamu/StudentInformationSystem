using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class StudentCourse
    {
        [Key]
        public int Id { get; set; }
        
        [ForeignKey("StudentDetails")]
        public int StudentId { get; set; }

        public StudentDetails StudentDetails { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }

    }
}
