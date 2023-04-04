using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Admin
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public int? Permission { get; set; }

    public bool? Status { get; set; }
}
