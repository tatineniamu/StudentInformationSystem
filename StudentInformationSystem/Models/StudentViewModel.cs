using StudentInformationSystem.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class StudentViewModel
    {
        public StudentDetails StudentDetails { get; set; }
        public Address Address { get; set; }
    }
}
