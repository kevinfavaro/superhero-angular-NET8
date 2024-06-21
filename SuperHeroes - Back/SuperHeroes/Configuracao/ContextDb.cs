
using SuperHeroes.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperHeroes.Configuracao
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options)
        {
        }

        public DbSet<Herois> Herois { get; set; }
        public DbSet<Superpoderes> Superpoderes { get; set; }
        public DbSet<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());

                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HeroisSuperpoderes>().HasKey(x => new { x.HeroiId, x.SuperpoderId });


            builder.Entity<HeroisSuperpoderes>().HasOne(x => x.Heroi)
                .WithMany(x => x.Superpoderes)
                .HasForeignKey(x => x.HeroiId);

            base.OnModelCreating(builder);
        }

        private static string GetConnectionString()
        {
            return "Server=localhost;Database=superheroes;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}
