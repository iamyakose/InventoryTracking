using InventoryTracking.Entities.DbSet;
using Microsoft.EntityFrameworkCore;

namespace InventoryTracking.DataService.Data
{
    public class AppDbContext : DbContext
    {      
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<StockTransaction> StockTransactions { get; set; }
        public virtual DbSet<Procurement> Procurements { get; set; }      

    } 
}
