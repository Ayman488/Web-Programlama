using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Havalemani> havalemaniler { get; set; } = new List<Havalemani>();


    }
}
