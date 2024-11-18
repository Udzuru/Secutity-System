using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Zaivki
{
    public int Id { get; set; }

    public int? People { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public int? Where { get; set; }

    public byte[]? Photo { get; set; }

    public string? Status { get; set; }

    public bool? Blacklist { get; set; }

    public string? File { get; set; }

    public double? Group { get; set; }

    public DateTime? Date { get; set; }

    public int? Type { get; set; }

    public virtual Person? PeopleNavigation { get; set; }

    public virtual Typ? TypeNavigation { get; set; }

    public virtual Employer? WhereNavigation { get; set; }
}
