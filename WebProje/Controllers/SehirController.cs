using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class SehirController : Controller
    {
        private readonly DbContextUcus _context;
        public SehirController(DbContextUcus context)
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
        public async Task<IActionResult> Create(Sehir sehir)
        {

            _context.Add(sehir);
            await _context.SaveChangesAsync();
            return RedirectToAction("SehirEkle", "Admin");

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

                if (id == null || _context.sehirler == null)
                {
                    return NotFound();
                }

                var sehir = await _context.sehirler.FirstOrDefaultAsync(m => m.Id == id);
                if (sehir == null)
                {
                    return NotFound();
                }

                return View(sehir);
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
                if (id == null || _context.sehirler == null)
                {
                    return NotFound();
                }

                var sehir = await _context.sehirler.FindAsync(id);
                if (sehir == null)
                {
                    return NotFound();
                }
                return View(sehir);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sehir sehir)
        {
            if (id != sehir.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(sehir);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SehirExists(sehir.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("SehirEkle", "Admin");
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
                if (id == null || _context.sehirler == null)
                {
                    return NotFound();
                }

                var sehir = await _context.sehirler
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (sehir == null)
                {
                    return NotFound();
                }

                return View(sehir);
            }
        }

        // POST: sehir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sehirler == null)
            {
                return Problem("Entity set 'KitaplikContext.Kitaplar'  is null.");
            }
            var sehir = await _context.sehirler.FindAsync(id);
            if (sehir != null)
            {
                _context.sehirler.Remove(sehir);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("SehirEkle", "Admin");
        }
        private bool SehirExists(int id)
        {
            return (_context.sehirler?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}

