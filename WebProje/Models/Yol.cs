using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Yol
    {
        [Key]
        public int Id { get; set; }
        public int Fiyat { get; set; }

        [ForeignKey("KalkisSehir")]
        public int KalkisSehirId { get; set; }
        public Sehir KalkisSehir { get; set; }

        [ForeignKey("VarisSehir")]
        public int VarisSehirId { get; set; }
        public Sehir VarisSehir { get; set; }

        [ForeignKey("UCAK")]
        public int UCAKID { get; set; }
        public Ucak UCAK { get; set; }


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

        public List<Rezervasyon> Rezervasyonlar { get; set; } = new List<Rezervasyon>();
    }
}
