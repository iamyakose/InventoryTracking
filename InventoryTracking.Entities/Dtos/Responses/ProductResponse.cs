using InventoryTracking.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.Entities.Dtos.Responses
{
    public class ProductResponse
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MinimumStockLevel { get; set; } = 0;       
    }
}
