using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Yol
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string KalkisSehir { get; set; }
        [Required]
        public string VarisSehri { get; set; }
        [Required]
        public DateTime KalkisZaman { get; set; }
        [Required]
        public DateTime VarisZaman { get; set; }
        public ICollection<Rezervasyon> Rezervasyons { get; set; }
    }
}
