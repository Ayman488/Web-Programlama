using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int KoltukNumarasi { get; set; }


        [ForeignKey("Yol")]
        public int SYolID { get; set; }
        public Yol Yol { get; set; }

       

        [ForeignKey("UcakNavigation")]
        public int Ucak { get; set; }
        public Ucak UcakNavigation { get; set; }

      

        [ForeignKey("Yolcu")]
        [Required]
        public int YolcuID { get; set; }
        public YeniKullanci Yolcu { get; set; }
    }
}
