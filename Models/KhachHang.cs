using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public int? SoDienThoai { get; set; }

    public int? TuoiKh { get; set; }

    public string? DiachiKh { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();
}
