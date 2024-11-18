using System;
using System.Collections.Generic;

namespace Main_api;

public partial class Person
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronimic { get; set; }

    public string? PhoneNumber { get; set; }

    public string? EMail { get; set; }

    public string? DateOfBirth { get; set; }

    public string? PassportNumber { get; set; }

    public double? PassportSeria { get; set; }

    public string? Organization { get; set; }

    public string? Comment { get; set; }

    public bool? Blacklist { get; set; }

    public virtual ICollection<Time> Times { get; } = new List<Time>();

    public virtual ICollection<Zaivki> Zaivkis { get; } = new List<Zaivki>();
}
