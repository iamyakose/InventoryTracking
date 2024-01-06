using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.DataService.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProcurementRepository Procurements { get; }
        IProductRepository Products { get; }
        IStockTransactionRepository StockTransactions { get; }

        Task<bool> CompleteAsync();
    }
}
