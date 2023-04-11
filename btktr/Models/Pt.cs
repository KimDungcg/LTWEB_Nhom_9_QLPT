using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class Pt
{
    public string MaPt { get; set; } = null!;

    public string? TenPt { get; set; }

    public string? Avatar { get; set; }

    public string? NamKn { get; set; }

    public int? TuoiPt { get; set; }

    public string? MaNoiHoc { get; set; }

    public string? MaTrinhDo { get; set; }

    public decimal? GiaPt { get; set; }

    public string? MaCalam { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; } = new List<HoaDon>();

    public virtual CaLam? MaCalamNavigation { get; set; }

    public virtual NoiHoc? MaNoiHocNavigation { get; set; }

    public virtual TrinhDo? MaTrinhDoNavigation { get; set; }

    public virtual ICollection<CauLacBo> MaClbs { get; } = new List<CauLacBo>();

    public virtual ICollection<Khoahoc> MaKhoaHocs { get; } = new List<Khoahoc>();
}
