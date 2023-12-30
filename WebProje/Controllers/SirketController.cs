using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class SirketController : Controller
    {
        private readonly DbContextUcus _context;
        public SirketController(DbContextUcus context)
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
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sirket sirket)
        {


            _context.Add(sirket);
            await _context.SaveChangesAsync();
            return RedirectToAction("SirketEkle", "Admin");

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
                if (id == null || _context.sirketler == null)
                {
                    return NotFound();
                }

                var Sirket = await _context.sirketler.FirstOrDefaultAsync(m => m.SirketId == id);
                if (Sirket == null)
                {
                    return NotFound();
                }

                return View(Sirket);
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
                if (id == null || _context.sirketler == null)
                {
                    return NotFound();
                }

                var Sirket = await _context.sirketler.FindAsync(id);
                if (Sirket == null)
                {
                    return NotFound();
                }
                return View(Sirket);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sirket sirket)
        {
            if (id != sirket.SirketId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(sirket);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SirketExists(sirket.SirketId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("SirketEkle", "Admin");
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
                if (id == null || _context.sirketler == null)
                {
                    return NotFound();
                }

                var Sirket = await _context.sirketler
                    .FirstOrDefaultAsync(m => m.SirketId == id);
                if (Sirket == null)
                {
                    return NotFound();
                }

                return View(Sirket);
            }
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.sirketler == null)
            {
                return Problem("Entity set 'KitaplikContext.Kitaplar'  is null.");
            }
            var Sirket = await _context.sirketler.FindAsync(id);
            if (Sirket != null)
            {
                _context.sirketler.Remove(Sirket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("SirketEkle", "Admin");
        }
        private bool SirketExists(int id)
        {
            return (_context.sirketler?.Any(e => e.SirketId == id)).GetValueOrDefault();
        }

    }

}

