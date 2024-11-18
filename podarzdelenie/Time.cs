using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Time
{
    public int Id { get; set; }

    public int? PeopleId { get; set; }

    public DateTime? TimeSt { get; set; }

    public DateTime? TimeEnd { get; set; }

    public virtual Person? People { get; set; }
}
