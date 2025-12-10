using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Entities;

namespace TasinmazBackend.Data
{
    public class TasinmazDbContext : DbContext
    {
        public TasinmazDbContext(DbContextOptions<TasinmazDbContext> options)
            : base(options)
        {
        }

        public DbSet<Il> Iller { get; set; }
        public DbSet<Ilce> Ilceler { get; set; }
        public DbSet<Mahalle> Mahalleler { get; set; }
        public DbSet<Tasinmaz> Tasinmazlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Il>().ToTable("Iller");
            modelBuilder.Entity<Ilce>().ToTable("Ilceler");
            modelBuilder.Entity<Mahalle>().ToTable("Mahalleler");
            modelBuilder.Entity<Tasinmaz>().ToTable("Tasinmazlar");

            modelBuilder.Entity<Il>()
                .HasMany(i => i.Ilceler)
                .WithOne(ic => ic.Il)
                .HasForeignKey(ic => ic.IlId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ilce>()
                .HasMany(ic => ic.Mahalleler)
                .WithOne(m => m.Ilce)
                .HasForeignKey(m => m.IlceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Mahalle>()
                .HasMany(m => m.Tasinmazlar)
                .WithOne(t => t.Mahalle)
                .HasForeignKey(t => t.MahalleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Il>().Property(i => i.Ad).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Ilce>().Property(i => i.Ad).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Mahalle>().Property(i => i.Ad).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Tasinmaz>().Property(t => t.Ada).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Tasinmaz>().Property(t => t.Parsel).HasMaxLength(20).IsRequired();
            modelBuilder.Entity<Tasinmaz>().Property(t => t.Nitelik).HasMaxLength(150);
            modelBuilder.Entity<Tasinmaz>().Property(t => t.Adres).HasMaxLength(300);

            // Seed Data
            modelBuilder.Entity<Il>().HasData(
                new Il { Id = 1, Ad = "Ankara" },
                new Il { Id = 2, Ad = "İstanbul" }
            );

            modelBuilder.Entity<Ilce>().HasData(
                new Ilce { Id = 1, Ad = "Çankaya", IlId = 1 },
                new Ilce { Id = 2, Ad = "Keçiören", IlId = 1 },
                new Ilce { Id = 3, Ad = "Kadıköy", IlId = 2 },
                new Ilce { Id = 4, Ad = "Beşiktaş", IlId = 2 }
            );

            modelBuilder.Entity<Mahalle>().HasData(
                new Mahalle { Id = 1, Ad = "Kızılay", IlceId = 1 },
                new Mahalle { Id = 2, Ad = "Dikmen", IlceId = 1 },
                new Mahalle { Id = 3, Ad = "Bağlum", IlceId = 2 },
                new Mahalle { Id = 4, Ad = "Moda", IlceId = 3 },
                new Mahalle { Id = 5, Ad = "Erenköy", IlceId = 3 },
                new Mahalle { Id = 6, Ad = "Levent", IlceId = 4 },
                new Mahalle { Id = 7, Ad = "Akatlar", IlceId = 4 }
            );
        }
    }
}
