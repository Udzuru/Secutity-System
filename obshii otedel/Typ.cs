using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Typ
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Zaivki> Zaivkis { get; } = new List<Zaivki>();
}
