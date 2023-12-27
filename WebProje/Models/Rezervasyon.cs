using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProje.Models
{
    public class Rezervasyon
    {
        [Key]
        public int Id { get; set; }
        public int KoltukNumarasi { get; set; }



        [ForeignKey("ID")]
        public int SYolID { get; set; }
        public Yol ID { get; set; }



        [ForeignKey("ucak")]
        public int Ucak { get; set; }
        public Ucak ucak { get; set; }



        [ForeignKey("YolcuId")]
        public int YolcuID { get; set; }
        public YeniKullanci YolcuId { get; set; }
    }
}
