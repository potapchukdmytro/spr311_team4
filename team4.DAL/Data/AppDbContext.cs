using Microsoft.EntityFrameworkCore;
using team4.DAL.Entities;

namespace team4.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);


            base.OnModelCreating(modelBuilder);
        }
    }
}
