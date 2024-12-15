using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Subjecttecher
{
    public int? SubjectId { get; set; }

    public int? TecherId { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Techer { get; set; }
}
