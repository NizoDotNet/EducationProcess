using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Subjects
{
    public class CreateModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public CreateModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CafedraId"] = new SelectList(_context.Cafedras, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Subject Subject { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Subjects.Add(Subject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
