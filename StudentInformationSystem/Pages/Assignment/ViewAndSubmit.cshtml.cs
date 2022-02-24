using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repository;

namespace StudentInformationSystem.Pages.Assignment
{
    public class ViewAndSubmitModel : PageModel
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public ViewAndSubmitModel(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        [BindProperty]
        public AssignmentViewModel AssignmentViewModel { get; set; }

        public void OnGet(int courseId)
        {
            var data = _assignmentRepository.GetAssignmentsForStudent(courseId);
            AssignmentViewModel = new AssignmentViewModel();
            AssignmentViewModel.Assignments = data;
        }
    }
}
