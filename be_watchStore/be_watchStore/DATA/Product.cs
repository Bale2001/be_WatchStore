using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Product
{
    public int ProId { get; set; }

    public string? ProName { get; set; }

    public string? ProCode { get; set; }

    public double? ProPrice { get; set; }

    public int? ProQuantity { get; set; }

    public string? ProDescription { get; set; }

    public bool? ProStatus { get; set; }

    public string? ProAvatar { get; set; }

    public bool? ProSale { get; set; }

    public DateTime? ProCreateDate { get; set; }

    public string? ProCreateBy { get; set; }

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Image> Images { get; } = new List<Image>();

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual Original? Supplier { get; set; }
}
