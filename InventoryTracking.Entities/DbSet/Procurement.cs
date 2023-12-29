namespace InventoryTracking.Entities.DbSet
{
    public class Procurement : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsSuggestion { get; set; }
        public Guid ProductId { get; set; }

        public virtual Product? Product { get; set; }
        // Add more procurement details as needed
    }
}
