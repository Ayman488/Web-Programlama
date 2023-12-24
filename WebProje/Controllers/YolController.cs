using Microsoft.AspNetCore.Mvc;
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
            return View();
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
            if (id == null || _context.Yollar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Yollar.FirstOrDefaultAsync(m => m.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }

            return View(kitap);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Yollar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Yollar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
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
            if (id == null || _context.Yollar == null)
            {
                return NotFound();
            }

            var kitap = await _context.Yollar
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
            return RedirectToAction("UcusEkle", "Admin");
        }
        private bool YolExists(int id)
        {
            return (_context.Yollar?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    
    }
}
