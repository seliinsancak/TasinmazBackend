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
        public DbSet<Mahalle> Mahaller { get; set; }
        public DbSet<Tasinmaz> Tasinmazlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       
            modelBuilder.Entity<Il>()
                .HasMany(i => i.Ilceler)
                .WithOne(ic => ic.Il)
                .HasForeignKey(ic => ic.IlId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Ilce>()
                .HasMany(ic => ic.Mahalleler)
                .WithOne(m => m.Ilce)
                .HasForeignKey(m => m.IlceId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Mahalle>()
                .HasMany(m => m.Tasinmazlar)
                .WithOne(t => t.Mahalle)
                .HasForeignKey(t => t.MahalleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
