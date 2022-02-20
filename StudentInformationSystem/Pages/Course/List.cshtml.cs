using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.Repository;

namespace StudentInformationSystem.Pages.Course
{
    public class ListModel : PageModel
    {
        private readonly ICourseRepository _courseRepo;

        public ListModel(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [BindProperty]
        public IList<DataBase.Entities.Course> Courses { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var courseList = await _courseRepo.GetAvailableCoursesAsync();
            Courses = courseList.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int courseId)
        {
            try
            {
                var studentId = HttpContext.Session.GetString("StudentId");
                await _courseRepo.RegisterCourse(courseId, Convert.ToInt32(studentId));
            }
            catch (Exception ex)
            {

            }
            return RedirectToPage("./Index");
        }
    }
}
