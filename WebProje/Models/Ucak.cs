using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Ucak
    {
        [Key]
        public int Id { get; set; }
        public int KoltukSayisi { get; set; }
        [ForeignKey("sirkets")]
        
        public int sirketsId { get; set; }
        public Sirket sirkets { get; set; }
        public List<Koltuk> Koltuklar { get; set; } = new List<Koltuk>();
        public List<Yol> Yollar { get; set; } = new List<Yol>();

        public List<Rezervasyon> rezervasyonlar { get; set; } = new List<Rezervasyon>();
    }
}
