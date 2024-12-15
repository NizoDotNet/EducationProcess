using EducationProcess.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EducationProcess.Pages
{
    public class IndexModel : PageModel
    {
        private readonly TedrisprosesiContext _db;

        public IndexModel(TedrisprosesiContext db)
        {
            _db = db;
        }

        public List<Subjecttecher> SubjectTeacher { get; set; } = [];

        public async Task OnGetAsync()
        {
            SubjectTeacher = await _db.Subjecttechers
                .Include(c => c.Techer)
                .Include(c => c.Subject)
                .ToListAsync();

        }
    }
}
