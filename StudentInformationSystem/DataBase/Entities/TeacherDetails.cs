using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.DataBase.Entities
{
    public class TeacherDetails
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
       
        [ForeignKey("Users")]
        public int? UserId { get; set; }
        public Users Users { get; set; }
        
    }
}
