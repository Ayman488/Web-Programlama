using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdminSayfasi()
        {
            
            return View();
        }
        public IActionResult UcusEkle(Ucak ucak)
        {
            // رمز لعرض صفحة إضافة طائرة
            return View(ucak);
        }

        public IActionResult YolEkle(Yol yol)
        {
            // رمز لعرض صفحة إضافة طريق
            return View();
        }

        public IActionResult SehirEkle(Sehir sehir)
        {
            // رمز لعرض صفحة إضافة مدينة
            return View();
        }
        public IActionResult HavalemaniEkle(Havalemani havalemani)
        {
            // رمز لعرض صفحة إضافة مدينة
            return View();
        }
    }
}
