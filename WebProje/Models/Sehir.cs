using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Havalemani> havalemaniler { get; set; }

    }
}
