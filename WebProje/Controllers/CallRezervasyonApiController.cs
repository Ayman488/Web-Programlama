using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CallRezervasyonApiController : Controller
    {
        private readonly DbContextUcus _context;
        public CallRezervasyonApiController(DbContextUcus context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Rezervasyon> rezervasyon = new List<Rezervasyon>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7149/api/RezervasyonApi");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            rezervasyon = JsonConvert.DeserializeObject<List<Rezervasyon>>(jsonResponse);


            return View(rezervasyon);
        }
    }
}
