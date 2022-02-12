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
    public class DeleteModel : PageModel
    {
        private readonly IStudentDetailsRepository _studentDetailsRepo;

        public DeleteModel(IStudentDetailsRepository studentDetailsRepo)
        {
            _studentDetailsRepo = studentDetailsRepo;
        }

        [BindProperty]
        public StudentDetails StudentDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            StudentDetails = await _studentDetailsRepo.GetById((int)id);

            if (StudentDetails == null)
                return NotFound();
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            StudentDetails = await _studentDetailsRepo.GetById((int)id);

            if (StudentDetails != null)
                await _studentDetailsRepo.DeleteAsync(StudentDetails);

            return RedirectToPage("./Index");
        }
    }
}
