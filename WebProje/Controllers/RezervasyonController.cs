using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebProje.Models;


namespace WebProje.Controllers
{
    public class RezervasyonController : Controller
    {
        private readonly DbContextUcus _context;

        public RezervasyonController(DbContextUcus context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            string currentUserEmail = HttpContext.Session.GetString("SessionUser");


            var rezervasyon = _context.Rezervasyonlar
             .Include(r => r.Yol)
             .Include(r => r.UcakNavigation)
             .Include(r => r.Yolcu)
             .Where(r => r.Yolcu.Email == currentUserEmail) // Filter by the current user's email
             .ToList();//here i want to just show that data is equals to my email because now its showing othere users is rezervasyons

            return View(rezervasyon);

        }
        [HttpGet("Rezrvasyon/List/{id}")]
        public async Task<IActionResult> List(int? id)
        {

            if (HttpContext.Session.GetString("SessionUser") is null)
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            else
            {
                string currentUserEmail = HttpContext.Session.GetString("SessionUser");


                var rezervasyon = _context.Rezervasyonlar
                 .Include(r => r.Yol)
                 .Include(r => r.UcakNavigation)
                 .Include(r => r.YolcuID)
                 .Where(r => r.Yolcu.Email == currentUserEmail) // Filter by the current user's email
                 .ToList();//here i want to just show that data is equals to my email because now its showing othere users is rezervasyons


                return View(rezervasyon);
            }
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
                ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id", "Id");
                ViewBag.YolId = new SelectList(_context.Yollar, "Id", "Id");
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Rezervasyon rezervasyon)
        {


            _context.Add(rezervasyon);
            await _context.SaveChangesAsync();
            //ViewBag.UcakID = new SelectList(_context.Ucaklar, "Id", "Id", rezervasyon.Ucak);
            //ViewBag.YolId = new SelectList(_context.Yollar, "Id", "Id", rezervasyon.SYolID);
            return View("List");

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
                if (id == null)
                {
                    return NotFound();
                }

                var rezervasyon = await _context.Rezervasyonlar
                    .Include(r => r.Yol)
                    .Include(r => r.UcakNavigation)
                    .Include(r => r.Yolcu)
                    .FirstOrDefaultAsync(r => r.Id == id);

                if (rezervasyon == null)
                {
                    return NotFound();
                }

                return View(rezervasyon);
            }
        }
        public async Task<IActionResult> Edit(int? id)
        {
            string currentUserEmail = HttpContext.Session.GetString("SessionUser");
            if (string.IsNullOrEmpty(currentUserEmail))
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            var userId = HttpContext.Session.GetInt32("SessionUserId"); // Assuming you store user ID as an int

            var reservation = await _context.Rezervasyonlar
                .Include(r => r.Yol)
                .Include(r => r.UcakNavigation)
                .Include(r => r.Yolcu)
                .FirstOrDefaultAsync(r => r.Id == id && r.Yolcu.Email == currentUserEmail);

            if (reservation == null)
            {
                return NotFound();
            }

            ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id", "Id", reservation.Ucak);
            ViewData["YolId"] = new SelectList(_context.Yollar, "Id", "Id", reservation.SYolID);
            ViewData["YolcuId"] = new SelectList(_context.yeniKullancis, "Id", "Id", reservation.YolcuID);

            return View(reservation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Rezervasyon rezervasyon)
        {
        

            // Ensure the ID of the reservation we are editing matches the ID of the reservation passed in.
            if (id != rezervasyon.Id)
            {
                return NotFound();
            }

            // Retrieve the current user's email from the session.
            string currentUserEmail = HttpContext.Session.GetString("SessionUser");
            if (string.IsNullOrEmpty(currentUserEmail))
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }

            // Fetch the existing reservation from the database.
            var existingReservation = await _context.Rezervasyonlar
                .AsNoTracking() // Use AsNoTracking to avoid tracking issues.
                .Include(r => r.Yolcu)
                .FirstOrDefaultAsync(r => r.Id == id);

            // Check if the reservation exists and if it belongs to the logged-in user.
            if (existingReservation == null || existingReservation.Yolcu.Email != currentUserEmail)
            {
                return NotFound();
            }

            // If the reservation belongs to the current user, update the reservation.
            try
            {
                _context.Update(rezervasyon);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!rezervasyonExists(rezervasyon.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Redirect back to the list view after a successful update.
            return RedirectToAction("List");
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
                if (id == null || _context.Rezervasyonlar == null)
                {
                    return NotFound();
                }

                var rezervasyon = await _context.Rezervasyonlar
                   .Include(r => r.Yol)
                   .Include(r => r.UcakNavigation)
                   .Include(r => r.Yolcu)
                   .FirstOrDefaultAsync(m => m.Id == id);
                if (rezervasyon == null)
                {
                    return NotFound();
                }

                return View(rezervasyon);
            }
        }
        // POST: Kitap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (_context.Rezervasyonlar == null)
            {
                return Problem("Entity set 'KitaplikContext.Kitaplar'  is null.");
            }
            var rezervasyon = await _context.Rezervasyonlar
                     .Include(r => r.Yol)
                     .Include(r => r.UcakNavigation)
                     .Include(r => r.Yolcu)
                     .FirstOrDefaultAsync(m => m.Id == id);
            if (rezervasyon != null)
            {
                _context.Rezervasyonlar.Remove(rezervasyon);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("List");
        }
        private bool rezervasyonExists(int id)
        {
            return (_context.Rezervasyonlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
