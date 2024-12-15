using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Faculties
{
    public class IndexModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public IndexModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        public IList<Faculty> Faculty { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Faculty = await _context.Faculties.ToListAsync();
        }
    }
}
