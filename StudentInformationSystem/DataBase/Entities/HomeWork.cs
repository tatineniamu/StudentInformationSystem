using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class HomeWork
    {
        [Key]
        public int Id { get; set; }
        public string SubmittedText { get; set; }
        public DateTime SubmittedDate { get; set; }
        public string GradeScore { get; set; }

        [ForeignKey("TeacherDetails")]
        public int GradedBy { get; set; }
        public TeacherDetails TeacherDetails { get; set; }

        [ForeignKey("StudentDetails")]
        public int StudentId { get; set; }
        public StudentDetails StudentDetails { get; set; }

        [ForeignKey("Assignments")]
        public int AssignmentId { get; set; }
        public Assignments Assignments { get; set; }

    }
}
