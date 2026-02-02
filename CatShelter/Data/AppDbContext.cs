using CatShelter.Models;
using Microsoft.EntityFrameworkCore;

namespace CatShelter.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<FavoriteCat> FavoriteCats { get; set; }
        public DbSet<CatVaccine> CatVaccines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cat>()
                .HasOne(b => b.Breed)
                .WithMany(c => c.Cats)
                .HasForeignKey(b => b.BreedId);

            modelBuilder.Entity<Adoption>()
                .HasOne(c => c.Cat)
                .WithOne(a => a.Adoption)
                .HasForeignKey<Adoption>(c => c.CatId);

            modelBuilder.Entity<Adoption>()
                .HasOne(u => u.User)
                .WithMany(a => a.Adoptions)
                .HasForeignKey(u => u.UserId);
        }
    }
}
