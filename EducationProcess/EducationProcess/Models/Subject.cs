using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Subject
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CafedraId { get; set; }

    public virtual Cafedra? Cafedra { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}
