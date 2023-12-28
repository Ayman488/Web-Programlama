using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;
namespace WebProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UcakApiController : Controller
    {
        private readonly DbContextUcus _context;
        public UcakApiController(DbContextUcus context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var Ucaklar = await _context.Ucaklar.ToListAsync();

            return Ok(Ucaklar);

        }
        [HttpGet("{id}")]

        public async Task<ActionResult> Get(int? id)
        {
            var Ucaklar = await _context.Ucaklar.FindAsync(id);

            return Ok(Ucaklar);

        }

        [HttpPost]
        public IActionResult Post([FromBody] Ucak u)
        {
            //if (ModelState.IsValid)  [ApiController] doğrulamayı yapoıypr
            _context.Ucaklar.Add(u);
            _context.SaveChanges();
            return Ok(u);
        }
    }
}
