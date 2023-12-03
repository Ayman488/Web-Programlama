using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class UcusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // Koltuk rezervasyon süreci
        public IActionResult RezerveKoltuk(int YolId, int KoltukNumarasi)
        {
            
            return RedirectToAction("Index");
        }


        // Rezervasyon onay sayfasını görüntüleyin
        public IActionResult RezervasyonOnayla(int reservationId)
        {
        
            return View();
        }


        // ödeme süreci
        public IActionResult OdemeYap(int reservationId)
        {
        

            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            // قم بتنفيذ عمليات تسجيل الدخول هنا
            // ...

            return RedirectToAction("Index");
        }
    }
}
