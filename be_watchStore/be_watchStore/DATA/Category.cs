using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Category
{
    public int CatId { get; set; }

    public string? CatName { get; set; }

    public string? CatMetaTitle { get; set; }

    public bool? CatStatus { get; set; }

    public string? CatDescription { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
