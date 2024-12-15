using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Specialization
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CafedraId { get; set; }

    public virtual Cafedra? Cafedra { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
