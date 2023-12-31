using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje.Models;


namespace WebProje.Controllers
{
    public class UcusController : Controller
    {
        private readonly DbContextUcus _context;
        public UcusController(DbContextUcus context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else { 

            return View();
            }
        }
        [HttpGet("Ucus/Index/{id}")]
        public async Task<IActionResult> Index(int? id)
        {

            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                if (id == null || _context.Rezervasyonlar == null)
                {
                    return NotFound();
                }

                var rezervasyon = await _context.Rezervasyonlar
                                        .Include(r => r.Yol)
                                        .Include(r => r.UcakNavigation)
                                        .Include(r => r.Yolcu)
                                        .FirstOrDefaultAsync(m => m.Id == id);

                if (rezervasyon == null)
                {
                    return NotFound();
                }

                return View(rezervasyon);
            }
        }
        // Koltuk rezervasyon süreci
        public IActionResult Rezervasyon()
        {
            
            ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id","Id");
            ViewBag.YolId = new SelectList(_context.Yollar, "Id", "Id");
            return View();
        }

        // POST: Rezervasyon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rezervasyon(Rezervasyon rezervasyon)
        {

            if (ModelState.IsValid)
            {

            }
            //_context.Add(rezervasyon);
            //await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(RezervasyonOnayla), new { reservationId = rezervasyon.Id });
                
       

            ViewBag.UcakID = new SelectList(_context.Ucaklar, "Id", "Id", rezervasyon.Ucak);
            ViewBag.YolId = new SelectList(_context.Yollar, "Id", "Id", rezervasyon.SYolID);
            return View(rezervasyon);
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
        //public interface IUserRepository
        //{
        //    YeniKullanci GetUserByEmail(string email);
        //}
        //public class UserRepository : IUserRepository
        //{
        //    private readonly DbContextUcus _context;

        //    public UserRepository(DbContextUcus context)
        //    {
        //        _context = context;
        //    }

        //    public YeniKullanci GetUserByEmail(string email)
        //    {
        //        return _context.yeniKullancis.FirstOrDefault(u => u.Email == email);
        //    }
        //}
        [HttpPost]
        public IActionResult Login(Login login)
        {


            if (_context.yeniKullancis.Any(e => e.Email == login.Email && e.Sifre == login.Sifre&&e.adminmi==true))
            {

                HttpContext.Session.SetString("SessionUser", login.Email);
                HttpContext.Session.SetString("IsAdmin", "true");   
                var cokOpt = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(10)
                };

                return RedirectToAction("AdminSayfasi", "Admin");
            }
            else if (_context.yeniKullancis.Any(e => e.Email == login.Email && e.Sifre == login.Sifre))
            {
                HttpContext.Session.SetString("SessionUser", login.Email);
                return View("Index");
            }
            else
            {
                TempData["error"] = "sifre veya email yanlis";
                return View();
            }
        }
        public IActionResult Kullanci()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Kullanci(YeniKullanci Kullanci)
        {
            _context.Add(Kullanci);
            await _context.SaveChangesAsync();
            return View("Rezervasyon");
        }

    }
}
