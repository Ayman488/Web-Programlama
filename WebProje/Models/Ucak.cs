using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Ucak
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int KoltukSayisi { get; set; }
        public ICollection<Rezervasyon> Rezervasyons { get; set; }
    }
}
