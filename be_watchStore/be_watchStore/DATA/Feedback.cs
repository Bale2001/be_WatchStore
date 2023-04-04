using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Feedback
{
    public int FebId { get; set; }

    public int? UserId { get; set; }

    public DateTime? FebDate { get; set; }

    public string? FebTitle { get; set; }

    public string? FebContent { get; set; }

    public string? FebReply { get; set; }

    public string? FebStatus { get; set; }

    public virtual User? User { get; set; }
}
