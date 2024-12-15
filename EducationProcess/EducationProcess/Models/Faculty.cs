using System;
using System.Collections.Generic;

namespace EducationProcess.Models;

public partial class Faculty
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

    public virtual ICollection<Cafedra> Cafedras { get; set; } = new List<Cafedra>();
}
