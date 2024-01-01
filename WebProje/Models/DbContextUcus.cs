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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Yol>()
                .HasOne(y => y.KalkisSehir)
                .WithMany(s => s.KalkisYollar)
                .HasForeignKey(y => y.KalkisSehirId);

            modelBuilder.Entity<Yol>()
                .HasOne(y => y.VarisSehir)
                .WithMany(s => s.VarisYollar)
                .HasForeignKey(y => y.VarisSehirId);

                        modelBuilder.Entity<Yol>()
                .HasOne(y => y.UCAK) // Assuming you have a navigation property in Yol for Ucak
                .WithMany(u => u.Yollar) // Assuming you have a navigation property in Ucak for Yollar
                .HasForeignKey(y => y.UCAKID); // Assuming you have a foreign key property in Yol for UcakId

        }


    }
}
