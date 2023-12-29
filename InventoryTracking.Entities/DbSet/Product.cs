namespace InventoryTracking.Entities.DbSet
{
    public class Product : BaseEntity
    {
        public Product() 
        {
            StockTransactions = new List<StockTransaction>();
        }       
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MinimumStockLevel { get; set; } = 0;       
        // One-to-many relationship with StockTransaction
        public virtual ICollection<StockTransaction> StockTransactions { get; set; }  // Collection navigation property to represent the stocktransactions on product.
    }
}
