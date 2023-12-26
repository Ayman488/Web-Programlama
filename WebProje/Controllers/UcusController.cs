﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Rezervesyon(Rezervasyon rezervasyon)
        {
            _context.Rezervasyonlar?.Any(e => e.Yol == rezervasyon.Yol).GetValueOrDefault("Login");
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        // Rezervasyon onay sayfasını görüntüleyin
        public IActionResult RezervasyonOnayla(int reservasyon)
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
            else if ((_context.yeniKullancis?.Any(e => e.Email == login.Email)).GetValueOrDefault())
            {
                return View("Rezervesyon");
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
