using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Koltuk
    {
        [Key]
        public int Id { get; set; }
        public bool IsAvailable { get; set; } = true;

        [ForeignKey("ucaks1")]
        public int UcakId { get; set; }
        public Ucak ucaks1 { get; set; }

    }
}
