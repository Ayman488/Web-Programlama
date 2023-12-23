using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class YeniKullanci
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Adi { get; set; }
        public string SoyAdi { get; set; }
        [Required(ErrorMessage = "Email Adrise gimeniz gerekiyor")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gimeniz gerekiyor")]
        public string Sifre { get; set; }
        public ICollection<Rezervasyon> Rezervasyons { get; set; }
    }
}
