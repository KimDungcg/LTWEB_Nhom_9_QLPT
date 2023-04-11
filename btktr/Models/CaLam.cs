using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class CaLam
{
    public string MaCaLam { get; set; } = null!;

    public string? TenCaLam { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();

    public virtual ICollection<Pt> Pts { get; } = new List<Pt>();
}
