using Microsoft.EntityFrameworkCore;

namespace Fabrika_Personel_Kayit.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Gorev> Gorevs { get; set; }
        public DbSet<Personel> Personels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // configures one-to-many relationship
            modelBuilder.Entity<Personel>().HasOne(x => x.Gorev).WithMany(c => c.Personels).HasForeignKey(p => p.GorevId);


        }
    }
}
