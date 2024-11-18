using System;
using System.Collections.Generic;

namespace Main_api;

public partial class ТипПользователя
{
    public int Id { get; set; }

    public string? ТипПользователя1 { get; set; }

    public virtual ICollection<Пользователи> Пользователиs { get; } = new List<Пользователи>();
}
