﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EducationProcess;
using EducationProcess.Models;

namespace EducationProcess.Pages.Teachers
{
    public class DeleteModel : PageModel
    {
        private readonly EducationProcess.TedrisprosesiContext _context;

        public DeleteModel(EducationProcess.TedrisprosesiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Teacher Teacher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                Teacher = teacher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher != null)
            {
                Teacher = teacher;
                _context.Teachers.Remove(Teacher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
