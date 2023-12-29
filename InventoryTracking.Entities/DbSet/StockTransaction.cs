namespace InventoryTracking.Entities.DbSet
{
    public class StockTransaction : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public StockTransactionType TransactionType { get; set; }

        // One-to-many relationship with Product
        public Guid ProductId { get; set; } // Foreign key property
        public virtual Product? Product { get; set; } // Navigation property to represent the product

    }
}
