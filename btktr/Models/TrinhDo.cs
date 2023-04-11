using System;
using System.Collections.Generic;

namespace btktr.Models;

public partial class TrinhDo
{
    public string MaTrinhDo { get; set; } = null!;

    public string? TenTrinhDo { get; set; }

    public virtual ICollection<Pt> Pts { get; } = new List<Pt>();
}
