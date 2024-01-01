using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Havalemani> Havalemaniler { get; set; } = new List<Havalemani>();
        public List<Yol> KalkisYollar { get; set; } = new List<Yol>();
        public List<Yol> VarisYollar { get; set; } = new List<Yol>();
    }
}
