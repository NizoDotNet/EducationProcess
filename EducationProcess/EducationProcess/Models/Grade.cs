﻿using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Grade
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public decimal? SemesterScore { get; set; }

    public decimal? ExamScore { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
