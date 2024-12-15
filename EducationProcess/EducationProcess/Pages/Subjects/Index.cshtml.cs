using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Subjects
{
    public class IndexModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public IndexModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Subject = await _context.Subjects
                .Include(s => s.Cafedra).ToListAsync();
        }
    }
}
