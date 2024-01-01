using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;
namespace WebProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonApiController : Controller
    {
        private readonly DbContextUcus _context;
        public RezervasyonApiController(DbContextUcus context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var rezervasyon = await _context.Rezervasyonlar
                .ToListAsync();

            return Ok(rezervasyon);

        }
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int? id)
        {
            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);

            return Ok(rezervasyon);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Rezervasyon r)
        {
            //if (ModelState.IsValid)  [ApiController] doğrulamayı yapoıypr
            _context.Rezervasyonlar.Add(r);
            _context.SaveChanges();
            return Ok(r);
        }

        // PUT api/<YazarApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int? id, [FromBody] Rezervasyon r)
        {
            if (id is null)
            {
                return NotFound();
            }
            var Rezervasyon = _context.Rezervasyonlar.FirstOrDefault(r => r.Id == id);
            if (Rezervasyon == null)
            {
                return NotFound();
            }
            Rezervasyon.KoltukNumarasi = r.KoltukNumarasi;

            _context.Update(Rezervasyon);
            _context.SaveChanges();
            return Ok(Rezervasyon);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }
            var Rezervasyon = _context.Rezervasyonlar.FirstOrDefault(z => z.Id == id);
            if (Rezervasyon == null)
            {
                return NotFound();
            }
           
            _context.Rezervasyonlar.Remove(Rezervasyon);
            _context.SaveChanges();
            return Ok(Rezervasyon);
        }
    }
}
