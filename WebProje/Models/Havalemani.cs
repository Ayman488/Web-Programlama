using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Havalemani
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string HavalemanininAdi { get; set; }
        [Required]
        public string Sehir { get; set; }
        
    }
}
