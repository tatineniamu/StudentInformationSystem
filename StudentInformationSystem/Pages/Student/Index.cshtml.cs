using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Repository;

namespace StudentInformationSystem.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly IStudentDetailsRepository _studentDetailsRepo;

        public IndexModel(IStudentDetailsRepository studentDetailsRepo)
        {
            _studentDetailsRepo = studentDetailsRepo;
        }

        public IList<StudentDetails> StudentDetails { get;set; }

        public async Task OnGetAsync()
        {
            var students = await _studentDetailsRepo.GetAllAsync();
            StudentDetails = students.ToList();
        }
    }
}
