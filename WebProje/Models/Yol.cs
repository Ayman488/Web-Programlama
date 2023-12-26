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
        private DateTime _kalkisZaman;
        [Required]
        public DateTime KalkisZaman
        {
            get => _kalkisZaman;
            set => _kalkisZaman = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _varisZaman;
        [Required]
        public DateTime VarisZaman
        {
            get => _varisZaman;
            set => _varisZaman = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public ICollection<Rezervasyon> Rezervasyons { get; set; }
    }
}
