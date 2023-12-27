using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Yol
    {
        [Key]
        public int Id { get; set; }
        public string KalkisSehir { get; set; }

        public string VarisSehri { get; set; }
        private DateTime _kalkisZaman;
        public DateTime KalkisZaman
        {
            get => _kalkisZaman;
            set => _kalkisZaman = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }
        private DateTime _varisZaman;
        public DateTime VarisZaman
        {
            get => _varisZaman;
            set => _varisZaman = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

       
        public List<Rezervasyon> rezervasyonlar { get; set; } = new List<Rezervasyon>();

    }
}
