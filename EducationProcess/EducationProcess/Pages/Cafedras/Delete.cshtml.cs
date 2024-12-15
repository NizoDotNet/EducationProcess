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
    public class DeleteModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public DeleteModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafedra = await _context.Cafedras.FindAsync(id);
            if (cafedra != null)
            {
                Cafedra = cafedra;
                _context.Cafedras.Remove(Cafedra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
