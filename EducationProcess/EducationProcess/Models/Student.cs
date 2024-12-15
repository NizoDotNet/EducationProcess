using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Pin { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public int? SpecializationId { get; set; }

    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();

    public virtual Specialization? Specialization { get; set; }
}
