namespace WebProje.Models
{
    public class Rezervasyon
    {
        public int Id { get; set; }
        public int YolId { get; set; }
        public int UcakId { get; set; }
        public int KoltukNumarasi { get; set; }
        public string YolcuAdi { get; set; }
    }
}
