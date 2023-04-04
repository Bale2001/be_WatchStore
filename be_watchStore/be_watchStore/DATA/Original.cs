using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Original
{
    public int SupplierId { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public int? Phone { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
