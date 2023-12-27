using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Ucak
    {
        [Key]
        public int Id { get; set; }
        public int KoltukSayisi { get; set; }
        public List<Rezervasyon> rezervasyonlar { get; set; } = new List<Rezervasyon>();
    }
}
