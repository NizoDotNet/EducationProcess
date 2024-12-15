using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Cafedras
{
    public class DetailsModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public DetailsModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        public Cafedra Cafedra { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafedra = await _context.Cafedras.FirstOrDefaultAsync(m => m.Id == id);
            if (cafedra == null)
            {
                return NotFound();
            }
            else
            {
                Cafedra = cafedra;
            }
            return Page();
        }
    }
}
