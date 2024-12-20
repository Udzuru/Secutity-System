﻿using System;
using System.Collections.Generic;

namespace Main_api;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Surname { get; set; }
}
