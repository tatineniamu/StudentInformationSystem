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
    public class IndexModel : PageModel
    {
        private readonly DataContext _context;

        public IndexModel(DataContext context)
        {
            _context = context;
        }

        public IList<StudentDetails> StudentDetails { get;set; }

        public async Task OnGetAsync()
        {
            StudentDetails = await _context.StudentDetails.ToListAsync();
        }
    }
}
