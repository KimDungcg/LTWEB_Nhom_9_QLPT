using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class BaiTap
{
    public string MaBaiTap { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? ChiTietBt { get; set; }

    public string? TenBaiTap { get; set; }

    public virtual ICollection<LichTap> MaLichTaps { get; } = new List<LichTap>();
}
