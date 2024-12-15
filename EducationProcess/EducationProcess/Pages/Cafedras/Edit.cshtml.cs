using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Cafedras
{
    public class EditModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public EditModel(EducationProcess.TedrisprosesiContext context)
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

            var cafedra =  await _context.Cafedras.FirstOrDefaultAsync(m => m.Id == id);
            if (cafedra == null)
            {
                return NotFound();
            }
            Cafedra = cafedra;
           ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cafedra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafedraExists(Cafedra.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CafedraExists(int id)
        {
            return _context.Cafedras.Any(e => e.Id == id);
        }
    }
}
