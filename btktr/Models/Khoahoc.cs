using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class Khoahoc
{
    public string MaKhoaHoc { get; set; } = null!;

    public string? TenKhoaHoc { get; set; }

    public decimal? GiaKhoahoc { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual ICollection<CauLacBo> MaClbs { get; } = new List<CauLacBo>();

    public virtual ICollection<LichTap> MaLichTaps { get; } = new List<LichTap>();

    public virtual ICollection<Pt> MaPts { get; } = new List<Pt>();
}
