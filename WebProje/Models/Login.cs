using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        [Required(ErrorMessage = "şifre giminiz gerekiyor!")]
        public string Sifre { get; set; }
    }
}
