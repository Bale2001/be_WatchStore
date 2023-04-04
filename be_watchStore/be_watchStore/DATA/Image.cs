using System;
using System.Collections.Generic;

namespace be_watchStore.DATA;

public partial class Image
{
    public int ImgId { get; set; }

    public int? ProId { get; set; }

    public string? ImgFile { get; set; }

    public virtual Product? Pro { get; set; }
}
