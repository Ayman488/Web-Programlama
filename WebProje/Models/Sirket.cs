using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Sirket
    {
        [Key]
        public int SirketId { get; set; }
        public string SirketName { get; set; }
        public List<Ucak> ucaklar { get; set; } = new List<Ucak>();

    }
}
