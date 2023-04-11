using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class HoaDon
{
    public string MaHoaDon { get; set; } = null!;

    public string? MaKh { get; set; }

    public string? MaKhoaHoc { get; set; }

    public string? MaPt { get; set; }

    public decimal? GiaHoaDon { get; set; }

    public TimeSpan? ThoigianThue { get; set; }

    public virtual KhachHang? MaKhNavigation { get; set; }

    public virtual Khoahoc? MaKhoaHocNavigation { get; set; }

    public virtual Pt? MaPtNavigation { get; set; }
}
