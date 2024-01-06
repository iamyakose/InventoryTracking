using InventoryTracking.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracking.DataService.Data
{
    public class AppDbContext : DbContext
    {      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<StockTransaction> StockTransactions { get; set; } = null!;
        public virtual DbSet<Procurement> Procurements { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<StockTransaction>().ToTable("StockTransaction");
            modelBuilder.Entity<Procurement>().ToTable("Procurement");
        }
    } 
}
