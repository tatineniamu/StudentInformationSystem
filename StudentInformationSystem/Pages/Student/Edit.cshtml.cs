using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;

namespace StudentInformationSystem.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly StudentInformationSystem.DataBase.DataContext _context;

        public EditModel(StudentInformationSystem.DataBase.DataContext context)
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

            StudentDetails = await _context.StudentDetails.Include(i => i.Address).FirstOrDefaultAsync(m => m.Id == id);

            if (StudentDetails == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(StudentDetails).State = EntityState.Modified;
            _context.Attach(StudentDetails.Address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailsExists(StudentDetails.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StudentDetailsExists(int id)
        {
            return _context.StudentDetails.Any(e => e.Id == id);
        }
    }
}
