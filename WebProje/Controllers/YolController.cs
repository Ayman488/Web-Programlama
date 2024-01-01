using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class YolController : Controller
    {
        private readonly DbContextUcus _context;
        public YolController(DbContextUcus context)
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
                ViewData["KalkisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
                ViewData["VarisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");

                var sirketler = _context.sirketler.Select(s => new { s.SirketId, s.SirketName }).ToList();
                ViewBag.SirketList = new SelectList(sirketler, "SirketId", "SirketName");


                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Yol yol)
        {

            _context.Add(yol);
            await _context.SaveChangesAsync();
            return RedirectToAction("YolEkle", "Admin");

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
                if (id == null || _context.Yollar == null)
                {
                    return NotFound();
                }

                var yol = await _context.Yollar.Include(m => m.KalkisSehir).Include(m => m.VarisSehir).Include(m => m.UCAK).ThenInclude(u => u.sirkets).FirstOrDefaultAsync(m => m.Id == id);
                if (yol == null)
                {
                    return NotFound();
                }
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View(yol);
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
                if (id == null || _context.Yollar == null)
                {
                    return NotFound();
                }

                var yol = await _context.Yollar.FindAsync(id);
                if (yol == null)
                {
                    return NotFound();
                }
                ViewData["KalkisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
                ViewData["VarisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View(yol);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Yol yol)
        {
            if (id != yol.Id)
            {
                return NotFound();
            }


            try
            {
                _context.Update(yol);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YolExists(yol.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("YolEkle", "Admin");
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
                if (id == null || _context.Yollar == null)
                {
                    return NotFound();
                }

                var yol = await _context.Yollar
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (yol == null)
                {
                    return NotFound();
                }
                var isAdmin = HttpContext.Session.GetString("IsAdmin") == "true";
                var layout = isAdmin ? "_AdminLayout" : "_Layout";
                ViewBag.Layout = layout;
                return View(yol);
            }
        }

        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Yollar == null)
            {
                return Problem("Entity set 'KitaplikContext.Kitaplar'  is null.");
            }
            var yoll = await _context.Yollar.FindAsync(id);
            if (yoll != null)
            {
                _context.Yollar.Remove(yoll);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("YolEkle", "Admin");
        }
        private bool YolExists(int id)
        {
            return (_context.Yollar?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    
    }
}
