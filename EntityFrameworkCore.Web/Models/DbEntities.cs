using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Web.Models
{
    public class DbEntities : DbContext
    {
        public DbEntities(DbContextOptions<DbEntities> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopProduct>()
                        .HasKey(entity => new { entity.ProductId, entity.ShopId });

            modelBuilder.Entity<ShopProduct>()
                        .HasOne(sp => sp.Product)
                        .WithMany(p => p.ProductShops)
                        .HasForeignKey(sp => sp.ProductId);

            modelBuilder.Entity<ShopProduct>()
                         .HasOne(sp => sp.Shop)
                         .WithMany(s => s.ShopProducts)
                         .HasForeignKey(sp => sp.ShopId);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
       // public DbSet<ShopProduct> ShopProducts { get; set; }
    }
}