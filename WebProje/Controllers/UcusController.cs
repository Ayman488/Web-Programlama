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
            return View();
        }
        // Koltuk rezervasyon süreci
        public IActionResult Rezervesyon()
        {
            ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id","Id");

            ViewData["YolId"] = new SelectList(_context.Yollar, "KalkisSehir", "VarisSehir");
            return View();
        }

        // POST: Rezervesyon/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Rezervasyon(Rezervasyon rezervasyon)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RezervasyonOnayla));

            }
            ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id", "Id", rezervasyon.UcakNavigation);
            ViewData["YolId"] = new SelectList(_context.Yollar, "KalkisSehir", "VarisSehir", rezervasyon.Yol);
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


            if (login.Email == "G201210591@Sakarya.edu.tr" && login.Sifre == "sau")
            {

                HttpContext.Session.SetString("SessionUser", login.Email);
                var cokOpt = new CookieOptions
                {
                    Expires = DateTime.Now.AddMinutes(10)
                };
                return RedirectToAction("AdminSayfasi", "Admin");
            }
            else if ((_context.yeniKullancis?.Any(e => e.Email == login.Email)).GetValueOrDefault()&& (_context.yeniKullancis?.Any(e => e.Sifre == login.Sifre)).GetValueOrDefault())
            {
                return View("Index");
            }
            else
                return View();
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
            return View("Rezervesyon");
        }

    }
}
