using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Comment
{
    public int ComId { get; set; }

    public int? ProId { get; set; }

    public int? UserId { get; set; }

    public string? ComContent { get; set; }

    public virtual Product? Pro { get; set; }

    public virtual User? User { get; set; }
}
