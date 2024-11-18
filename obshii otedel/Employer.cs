using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Employer
{
    public int Id { get; set; }

    public string? Snp { get; set; }

    public string? Where { get; set; }

    public string? Otdel { get; set; }

    public double? Code { get; set; }

    public virtual ICollection<Zaivki> Zaivkis { get; } = new List<Zaivki>();
}
