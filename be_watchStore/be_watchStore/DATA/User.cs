using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class User
{
    public int UserId { get; set; }

    public string? Email { get; set; }

    public string? Passworld { get; set; }

    public string? Name { get; set; }

    public int? Phone { get; set; }

    public string? Address { get; set; }

    public DateTime? Birthday { get; set; }

    public bool? Status { get; set; }

    public string? About { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Feedback> Feedbacks { get; } = new List<Feedback>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
