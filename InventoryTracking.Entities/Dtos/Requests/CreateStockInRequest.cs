﻿using InventoryTracking.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.Entities.Dtos.Requests
{
    public class CreateStockTransactionRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public StockTransactionType TransactionType { get; set; }
        public Product? Product { get; set; } = null!;
    }
}
