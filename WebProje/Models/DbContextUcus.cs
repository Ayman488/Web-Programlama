using Microsoft.EntityFrameworkCore;

namespace WebProje.Models
{
    public class DbContextUcus : DbContext
    {
        public DbSet<Ucak> Ucaklar { get; set; }
        public DbSet<Rezervasyon> Rezervasyonlar { get; set; }
        public DbSet<Yol> Yollar { get; set; }
        public DbSet<YeniKullanci> yeniKullancis { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Havalemani> havalemaniler { get; set; }
        public DbSet<Sehir> sehirler { get; set; }
        public DbSet<Sirket> sirketler { get; set; }
        public DbSet<Koltuk> Koltuklar { get; set; }
        public DbContextUcus(DbContextOptions<DbContextUcus> options) : base(options) { }
        

    }
}
