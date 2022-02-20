using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentInformationSystem.DataBase.Entities;
using StudentInformationSystem.Repository;
using StudentInformationSystem.Services;

namespace StudentInformationSystem.Pages.login
{
    public class LoginModel : PageModel
    {
        const string SessionUserType = "UserType";
        const string SessionStudentId = "StudentId";

        private readonly IUsersRepository _usersRepository;
        private readonly IStudentDetailsRepository _studentDetailsRepo;
        private readonly ISessionManager _sessionManager;

        public LoginModel(IUsersRepository usersRepository, IStudentDetailsRepository studentDetailsRepo, ISessionManager sessionManager)
        {
            _usersRepository = usersRepository;
            _studentDetailsRepo = studentDetailsRepo;
            _sessionManager = sessionManager;
        }

        [BindProperty]
        public Users Users { get; set; }

        public IActionResult OnGet()
        {
            HttpContext.Session.Remove(SessionUserType);
            HttpContext.Session.Remove(SessionStudentId);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var userDetails = await _usersRepository.UserLogin(Users);
                if (userDetails != null)
                {
                    switch (userDetails.RoleName)
                    {
                        case "Admin":
                            return RedirectToPage("/student/index");
                        case "Student":
                            HttpContext.Session.SetString(SessionUserType, "Student");
                            //get student details
                            var studentDetails = await  _studentDetailsRepo.GetByUserId(userDetails.Id);
                            HttpContext.Session.SetString(SessionStudentId, studentDetails.Id.ToString());
                            //navigate to detail page
                            return RedirectToPage("/student/details", new {id = studentDetails.Id } );
                        case "Teacher":
                            break;
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return RedirectToPage("./Index");
        }
    }
}
