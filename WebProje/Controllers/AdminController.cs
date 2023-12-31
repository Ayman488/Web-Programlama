﻿using Microsoft.AspNetCore.Mvc;
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
            var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
            var layout = isAdmin ? "_AdminLayout" : "_Layout";
            ViewBag.Layout = layout;
            return View();
            
        }
        public IActionResult UcakEkle(Ucak ucak)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                var Ucak1 = _context.Ucaklar.Include(m=>m.sirkets)
                    .ToList();
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
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                var Yol1 = _context.Yollar.Include(m=>m.KalkisSehir).Include(m=>m.VarisSehir).Include(m=>m.UCAK).ThenInclude(u => u.sirkets).ToList();
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
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
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
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                var havalemani1 = _context.havalemaniler
                    .Include(m=>m.Sehir)
                    .ToList();
                return View(havalemani1);
            }
        }
        public IActionResult SirketEkle(Sirket Sirkets)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                var Sirkets1 = _context.sirketler.ToList();
                return View(Sirkets1);
            }
        }




        //koltuk sec 
       

        public IActionResult UsrLogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Ucus");
        }
        
    }
}
