using System;
using System.Collections.Generic;

namespace web_propusk.Models;

public partial class Typ
{
    public int Id { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Zaivki> Zaivkis { get; } = new List<Zaivki>();
}
