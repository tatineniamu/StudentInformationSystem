using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;

namespace StudentInformationSystem.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDetailsRepository _studentDetailsRepo;

        public CreateModel(IStudentDetailsRepository studentDetailsRepo)
        {
            _studentDetailsRepo = studentDetailsRepo;
        }

        [BindProperty]
        public StudentViewModel StudentViewModel { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                //save student details
                var studentDetails = new StudentDetails();
                studentDetails = StudentViewModel.StudentDetails;
                studentDetails.Address = StudentViewModel.Address;

                //_context.StudentDetails.Add(studentDetails);
                //await _context.SaveChangesAsync();
                await _studentDetailsRepo.AddAsync(studentDetails);
            }
            catch (Exception ex) { 
            
            }
            return RedirectToPage("./Index");
        }
    }
}
