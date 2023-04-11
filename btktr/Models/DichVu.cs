using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class DichVu
{
    public string MaDichVu { get; set; } = null!;

    public string? Avatar { get; set; }

    public string? ChiTietDv { get; set; }

    public string? TenDichVu { get; set; }

    public virtual ICollection<CauLacBo> MaClbs { get; } = new List<CauLacBo>();
}
