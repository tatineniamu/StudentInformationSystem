using StudentInformationSystem.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class AssignmentViewModel
    {
        public List<Assignments> Assignments{ get; set; }
        public string HomeWorkText { get; set; }
    }
}
