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
    public class EditModel : PageModel
    {
        private readonly IStudentDetailsRepository _studentDetailsRepo;

        public EditModel(IStudentDetailsRepository studentDetailsRepo)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                await _studentDetailsRepo.UpdateAsync(StudentDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailsExists(StudentDetails.Id))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private bool StudentDetailsExists(int id)
        {
            return _studentDetailsRepo.CheckStudentExists(id);
        }
    }
}
