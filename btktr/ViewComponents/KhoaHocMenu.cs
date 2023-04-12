using btktr.Models;
using btktr.Repository;
using Microsoft.AspNetCore.Mvc;
namespace btktr.ViewComponents
{
    public class KhoaHocMenu: ViewComponent
    {
        private readonly IKhoaHoc _khoahocc;

        public KhoaHocMenu(IKhoaHoc KhoahocRepon) { 
            _khoahocc = KhoahocRepon;
        }
        public IViewComponentResult Invoke()
        {
            var khoahocc = _khoahocc.GetAllkhoahoc().OrderBy(X => X.TenKhoaHoc);
            return View(khoahocc);
        }
    }
}
