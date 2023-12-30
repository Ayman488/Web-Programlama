﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class UcakController : Controller
    {
        private readonly DbContextUcus _context;
        public UcakController(DbContextUcus context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {

                ViewData["SirketID"] = new SelectList(_context.sirketler, "SirketId", "SirketName");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Ucak ucak)
        {

           
                _context.Add(ucak);
                await _context.SaveChangesAsync();
                koltuklarEkle(ucak.Id, ucak.KoltukSayisi);
                ViewData["SirketID"] = new SelectList(_context.sirketler, "SirketId", "SirketName");
                return RedirectToAction("UcusEkle", "Admin");

        }
        private void koltuklarEkle(int ucakId, int koltuksayisi)
        {
            for (int i = 0; i < koltuksayisi; i++)
            {
                Koltuk yenikoltuk = new Koltuk
                {
                    UcakId = ucakId,
                    IsAvailable = true
                };

                _context.Koltuklar.Add(yenikoltuk);
            }

            _context.SaveChanges();
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                if (id == null || _context.Ucaklar == null)
                {
                    return NotFound();
                }

                var Ucak = await _context.Ucaklar.FirstOrDefaultAsync(m => m.Id == id);
                if (Ucak == null)
                {
                    return NotFound();
                }

                return View(Ucak);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                if (id == null || _context.Ucaklar == null)
                {
                    return NotFound();
                }

                var Ucak = await _context.Ucaklar.FindAsync(id);
                if (Ucak == null)
                {
                    return NotFound();
                }
                return View(Ucak);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ucak ucak)
        {
            if (id != ucak.Id)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(ucak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UcakExists(ucak.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            return RedirectToAction("UcusEkle", "Admin");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                if (id == null || _context.Ucaklar == null)
                {
                    return NotFound();
                }

                var Ucak = await _context.Ucaklar
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Ucak == null)
                {
                    return NotFound();
                }

                return View(Ucak);
            }
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.Ucaklar == null)
            {
                return Problem("Entity set 'KitaplikContext.Kitaplar'  is null.");
            }
            var Ucak = await _context.Ucaklar.FindAsync(id);
            if (Ucak != null)
            {
                _context.Ucaklar.Remove(Ucak);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("UcusEkle", "Admin");
        }
        private bool UcakExists(int id)
        {
            return (_context.Ucaklar?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
    
}
