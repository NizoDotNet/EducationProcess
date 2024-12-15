using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Grades
{
    public class IndexModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public IndexModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        public IList<Grade> Grade { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Grade = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Include(g => g.Teacher).ToListAsync();
        }
    }
}
