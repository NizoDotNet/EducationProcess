using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Grades
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
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
        ViewData["SubjectId"] = new SelectList(_context.Subjects, "Id", "Id");
        ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Grade Grade { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Grades.Add(Grade);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
