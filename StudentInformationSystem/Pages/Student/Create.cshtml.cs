using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentInformationSystem.DataBase;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Models;

namespace StudentInformationSystem.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly StudentInformationSystem.DataBase.DataContext _context;

        public CreateModel(StudentInformationSystem.DataBase.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                //save student details
                var studentDetails = new StudentDetails();
                studentDetails = StudentViewModel.StudentDetails;
                studentDetails.Address = StudentViewModel.Address;

                _context.StudentDetails.Add(studentDetails);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { 
            
            }
            return RedirectToPage("./Index");
        }
    }
}
