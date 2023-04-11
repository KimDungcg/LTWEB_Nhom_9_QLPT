using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class NhanVien
{
    public string MaNv { get; set; } = null!;

    public string? TenNv { get; set; }

    public int? TuoiNv { get; set; }

    public int? SoDienThoaiNv { get; set; }

    public string? DiaChiNv { get; set; }

    public string? MaCaLam { get; set; }

    public virtual CaLam? MaCaLamNavigation { get; set; }
}
