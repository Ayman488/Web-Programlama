using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Havalemani
    {
        [Key]
        public int Id { get; set; }
        public string HavalemanininAdi { get; set; }


        [ForeignKey("sehir")]
        public int SehirId { get; set; }
        public Sehir sehir { get; set; }

    }
}
