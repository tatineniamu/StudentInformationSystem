using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;

namespace StudentInformationSystem.Pages.Student
{
    public class DeleteModel : PageModel
    {
        private readonly StudentInformationSystem.DataBase.DataContext _context;

        public DeleteModel(StudentInformationSystem.DataBase.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentDetails StudentDetails { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentDetails = await _context.StudentDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (StudentDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            StudentDetails = await _context.StudentDetails.Include(i => i.Address).FirstOrDefaultAsync(f => f.Id == id);

            if (StudentDetails != null)
            {
                _context.Address.Remove(StudentDetails.Address);
                _context.StudentDetails.Remove(StudentDetails);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
