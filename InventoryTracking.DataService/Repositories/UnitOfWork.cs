using InventoryTracking.DataService.Data;
using InventoryTracking.DataService.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.DataService.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appDbContext;

        public IProcurementRepository Procurements { get; }

        public IProductRepository Products { get; } 

        public IStockTransactionRepository StockTransactions{ get; }


        public UnitOfWork(AppDbContext appDbContext, ILoggerFactory loggerFactory)
        {
            _appDbContext = appDbContext;
            var logger = loggerFactory.CreateLogger("logs");

            Procurements = new ProcurementRepository(_appDbContext, logger);
            Products = new ProductRepository(_appDbContext, logger);
            StockTransactions = new StockTransactionRepository(_appDbContext, logger);
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _appDbContext.SaveChangesAsync();
            return result > 0;
        }
        public void Dispose() 
        {
            _appDbContext.Dispose();
        }
    }
}
