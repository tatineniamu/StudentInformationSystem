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
    public class RegisteredClassesModel : PageModel
    {
        private readonly ICourseRepository _courseRepo;

        public RegisteredClassesModel(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        public async Task OnGet()
        {
            var studentId = HttpContext.Session.GetString("StudentId");
            var data = await _courseRepo.GetRegisteredCoursesAsync(Convert.ToInt32(studentId));
        }
    }
}
