using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProje.Models;
using System.Diagnostics;
using NuGet.Protocol.Plugins;


namespace WebProje.Controllers
{
    public class UcusController : Controller
    {
        private readonly DbContextUcus _context;
        public UcusController(DbContextUcus context)
        {
            _context = context;
        }
       
        // Koltuk rezervasyon süreci
        

        // POST: Rezervasyon/Create
    
        public IActionResult Login()
        {
          

            return View();
        }
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
                return View("AnaSayfaYolSecme");
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
            HttpContext.Session.SetInt32("SessionUserId", Kullanci.Id);
            await _context.SaveChangesAsync();
            return View("Login");
        }

    }
}
