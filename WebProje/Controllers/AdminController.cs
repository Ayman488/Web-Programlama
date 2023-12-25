using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class AdminController : Controller
    {
        private readonly DbContextUcus _context;
        public AdminController(DbContextUcus context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            var UcakContext = _context.Ucaklar.Include(k => k.Id);
            return View(await UcakContext.ToListAsync());
        }
        public IActionResult AdminSayfasi()
        {
           
                return View();
            
        }
        public IActionResult UcusEkle(Ucak ucak)
        {

            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var Ucak1 = _context.Ucaklar.ToList();
                return View(Ucak1);
            }
        }

        public IActionResult YolEkle(Yol yol)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var Yol1 = _context.Yollar.ToList();
                return View(Yol1);
            }
        }

        public IActionResult SehirEkle(Sehir sehir)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var Sehir1 = _context.sehirler.ToList();
                return View(Sehir1);
            }
        }
        public IActionResult HavalemaniEkle(Havalemani havalemani)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var havalemani1 = _context.havalemaniler.ToList();
                return View(havalemani1);
            }
        }
        public IActionResult UsrLogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Ucus");
        }
        
    }
}
