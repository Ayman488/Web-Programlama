using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Ucak ucak)
        {
           
                _context.Add(ucak);
                await _context.SaveChangesAsync();
            return RedirectToAction("UcusEkle", "Admin");

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Ucaklar.FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Ucaklar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
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
            if (id == null || _context.Ucaklar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Ucaklar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
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
            var kitap = await _context.Ucaklar.FindAsync(id);
            if (kitap != null)
            {
                _context.Ucaklar.Remove(kitap);
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
