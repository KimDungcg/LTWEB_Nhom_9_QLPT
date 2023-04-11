using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class CauLacBo
{
    public string MaClb { get; set; } = null!;

    public string? TenClb { get; set; }

    public string? Avatar { get; set; }

    public string? ChiTietClb { get; set; }

    public string? DiachiClb { get; set; }

    public virtual ICollection<DichVu> MaDichVus { get; } = new List<DichVu>();

    public virtual ICollection<Khoahoc> MaKhoaHocs { get; } = new List<Khoahoc>();

    public virtual ICollection<Pt> MaPts { get; } = new List<Pt>();
}
