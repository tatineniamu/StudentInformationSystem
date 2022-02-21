using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;

namespace StudentInformationSystem.Pages.Assignment
{
    public class SubmitModel : PageModel
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public SubmitModel(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [BindProperty]
        public HomeWork HomeWork { get; set; }

        public async Task<IActionResult> OnGet(int assignmentId)
        {
            var studentId = HttpContext.Session.GetString("StudentId");
            var data = await _assignmentRepository.CheckAndGetHomeWork(assignmentId, Convert.ToInt32(studentId));
            HomeWork = data;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _assignmentRepository.SaveHomeWork(HomeWork);

            return RedirectToPage("./Index");
        }
    }
}
