using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? ProId { get; set; }

    public int? OrId { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Or { get; set; }

    public virtual Product? Pro { get; set; }
}
