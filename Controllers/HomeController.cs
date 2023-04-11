using btktr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace btktr.Controllers
{
    public class HomeController : Controller
    {
        MovieWebContext db = new MovieWebContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var ListCLB = db.CauLacBos.ToList();
            return View(ListCLB);
        }
        public IActionResult ChiTietCauLacBo(string MaCLB)
        {
            var CauLacBo = db.CauLacBos.SingleOrDefault(x=>x.MaClb == MaCLB);
            var anhCLB = db.CauLacBos.Where(x=>x.MaClb==MaCLB).ToList();
            ViewBag.anhCLB = anhCLB;
            return View(CauLacBo);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}