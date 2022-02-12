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
    public class DetailsModel : PageModel
    {
        private readonly StudentInformationSystem.DataBase.DataContext _context;

        public DetailsModel(StudentInformationSystem.DataBase.DataContext context)
        {
            _context = context;
        }

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
    }
}
