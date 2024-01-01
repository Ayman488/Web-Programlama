using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class HavalemaniController : Controller
    {
        private readonly DbContextUcus _context;
        public HavalemaniController(DbContextUcus context)
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
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                ViewBag.SehirId = new SelectList(_context.sehirler, "Id", "Name");

                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Havalemani havalemani)
        {

            _context.Add(havalemani);
            await _context.SaveChangesAsync();
            return RedirectToAction("HavalemaniEkle", "Admin");

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
                if (id == null || _context.havalemaniler == null)
                {
                    return NotFound();
                }

                var havalemani = await _context.havalemaniler.Include(h=>h.Sehir).SingleOrDefaultAsync(h => h.Id == id);

                if (havalemani == null)
                {
                    return NotFound();
                }
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View(havalemani);
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
                if (id == null || _context.havalemaniler == null)
                {
                    return NotFound();
                }

                var havalemani = await _context.havalemaniler.FindAsync(id);
                if (havalemani == null)
                {
                    return NotFound();
                }
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                ViewBag.SehirId = new SelectList(_context.sehirler, "Id", "Name");
                return View(havalemani);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Havalemani havalemani)
        {
            if (id != havalemani.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(havalemani);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HavalemaniExists(havalemani.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("HavalemaniEkle", "Admin");
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
                if (id == null || _context.havalemaniler == null)
                {
                    return NotFound();
                }

                var havalemani = await _context.havalemaniler
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (havalemani == null)
                {
                    return NotFound();
                }
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View(havalemani);
            }
        }

        // POST: sehir/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.havalemaniler == null)
            {
                return Problem("Entity set 'havalemaniContext.havalemaniler'  is null.");
            }
            var havalemani = await _context.havalemaniler.FindAsync(id);
            if (havalemani != null)
            {
                _context.havalemaniler.Remove(havalemani);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("HavalemaniEkle", "Admin");
        }
        private bool HavalemaniExists(int id)
        {
            return (_context.havalemaniler?.Any(e => e.Id == id)).GetValueOrDefault();
        }


    }
}

