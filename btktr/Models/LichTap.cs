using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class LichTap
{
    public string MaLichTap { get; set; } = null!;

    public string? TenLichTap { get; set; }

    public virtual ICollection<BaiTap> MaBaitaps { get; } = new List<BaiTap>();
}
