using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int KoltukNumarasi { get; set; }
        [Required]
        public Yol Yol { get; set; }
        [Required]
        public int Ucak { get; set; }
        [Required]
        public YeniKullanci YolcuAdi { get; set; }
    }
}
