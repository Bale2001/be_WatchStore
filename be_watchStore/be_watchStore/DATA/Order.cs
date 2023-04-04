using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Order
{
    public int OrId { get; set; }

    public string? OrCode { get; set; }

    public DateTime? OrDate { get; set; }

    public double? OrPrice { get; set; }

    public string? OrAddressTo { get; set; }

    public string? OrStatus { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual User? User { get; set; }
}
