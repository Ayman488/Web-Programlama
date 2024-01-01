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
            string UserEmail = HttpContext.Session.GetString("SessionUser");


            var rezervasyon = _context.Rezervasyonlar
                  .Include(r => r.Yol.KalkisSehir.KalkisYollar)
                  .Include(r => r.Yol.VarisSehir.VarisYollar)
                  .Include(r => r.UcakNavigation)
                  .Include(r => r.Yolcu)
                  .Where(r => r.Yolcu.Email == UserEmail)
                  .ToList();

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
                string UserEmail = HttpContext.Session.GetString("SessionUser");


              var rezervasyon =  _context.Rezervasyonlar
                    .Include(r=>r.Yol.KalkisSehir)
                    .Include(r => r.Yol.VarisSehir)
                    .Include(r => r.UcakNavigation)
                    .Include(r => r.Yolcu)
                    .Where(r => r.Yolcu.Email == UserEmail)
                    .ToList();

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

                ViewData["KalkisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
                ViewData["VarisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> YolAra(int kalkisSehirId, int varisSehirId)
        {
            var Yol = await _context.Yollar
                               .Include(y => y.KalkisSehir)
                               .Include(y => y.VarisSehir)
                               .Where(y => y.KalkisSehirId == kalkisSehirId && y.VarisSehirId == varisSehirId)
                               .ToListAsync();
            if (!Yol.Any())
            {
                TempData["YolYok"] = "Yol Bulunmadı";
                return RedirectToAction("Create"); 
            }
            return View("YolSec", Yol);
        }
        [HttpPost]
        public async Task<IActionResult> KoltukSec(int yolId)
        {
        
         
                var Koltuklar = await _context.Koltuklar.Where(k=> k.IsAvailable).ToListAsync();
            ViewBag.YolId = yolId;
      
            return View(Koltuklar);
        }


        [HttpPost]
        public async Task<IActionResult> KoltukOnayala(int selectedSeatId, int yolId,int koltunkNumarasi)
        {
            // Retrieve the selected seat from the database
            var seat = await _context.Koltuklar
                                     .FirstOrDefaultAsync(k => k.Id == selectedSeatId && k.IsAvailable);

            

            // Retrieve the yol (Yol) and the current user
            var yol = await _context.Yollar.FindAsync(yolId);

            var currentUserEmail = HttpContext.Session.GetString("SessionUser");
            var currentUser = await _context.yeniKullancis.FirstOrDefaultAsync(u => u.Email == currentUserEmail);

            if (yol == null || currentUser == null)
            {
                // Handle the error appropriately
                TempData["Error"] = "An error occurred while processing your request.";
                return RedirectToAction("Create");
            }

            // Create a new reservation
            var reservation = new Rezervasyon
            {
                KoltukNumarasi = seat.SeatNumber,
                SYolID = yolId, // Assuming SYolID is your foreign key to Yol
                YolcuID = currentUser.Id, // Set this to the current user's ID
                Ucak = yol.UCAKID // Set this to the yol's UcakId
            };

            
            seat.IsAvailable = false;

         
            _context.Add(reservation);
            await _context.SaveChangesAsync();

           
            return RedirectToAction("KoltukOnayala1", new { id = reservation.Id });
        }

        public async Task<IActionResult> KoltukOnayala1(int id)
        {
            var reservation = await _context.Rezervasyonlar
                                            .Include(r => r.Yol)
                                            .ThenInclude(y => y.KalkisSehir)
                                            .Include(r => r.Yol)
                                            .ThenInclude(y => y.VarisSehir)
                                            .FirstOrDefaultAsync(r => r.Id == id);

            if (reservation == null)
            {
                // Handle the case where reservation is not found
                return View("Error"); // You should have an Error view to handle such cases
            }

            return View(reservation);
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
                    .Include(r=>r.Yol.KalkisSehirId)
                    .Include(r => r.Yol.VarisSehirId)
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
            string UserEmail = HttpContext.Session.GetString("SessionUser");
            if (string.IsNullOrEmpty(UserEmail))
            {
                TempData["hata"] = "Lütfen Login olunuz";
                return RedirectToAction("Login", "Ucus");
            }
            var userId = HttpContext.Session.GetInt32("SessionUserId"); // Assuming you store user ID as an int

            var reservation = await _context.Rezervasyonlar
                    .Include(r => r.Yol.KalkisSehirId)
                    .Include(r => r.Yol.VarisSehirId)
                    .Include(r => r.UcakNavigation)
                    .Include(r => r.Yolcu)
                    .FirstOrDefaultAsync(r => r.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            ViewData["UcakID"] = new SelectList(_context.Ucaklar, "Id", "Id", reservation.Ucak);
            ViewData["KalkisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
            ViewData["VarisSehirId"] = new SelectList(_context.sehirler, "Id", "Name");
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
            string UserEmail = HttpContext.Session.GetString("SessionUser");
            if (string.IsNullOrEmpty(UserEmail))
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
            if (existingReservation == null || existingReservation.Yolcu.Email != UserEmail)
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
                     .Include(r => r.Yol.KalkisSehirId)
                     .Include(r => r.Yol.VarisSehirId)
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
