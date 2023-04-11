using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class NoiHoc
{
    public string MaNoiHoc { get; set; } = null!;

    public string? TenNoiHoc { get; set; }

    public virtual ICollection<Pt> Pts { get; } = new List<Pt>();
}
