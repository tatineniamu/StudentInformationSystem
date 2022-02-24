using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class Assignments
    {
        [Key]
        public int Id { get; set; }
        public string TopicName { get; set; }
        public DateTime DueDate { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("TeacherDetails")]
        public int PostedById { get; set; }
        public TeacherDetails TeacherDetails { get; set; }

    }
}
