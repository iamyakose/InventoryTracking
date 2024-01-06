using InventoryTracking.DataService.Data;
using InventoryTracking.DataService.Repositories.Interfaces;
using InventoryTracking.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.DataService.Repositories
{
    public class StockTransactionRepository : GenericRepository<StockTransaction>, IStockTransactionRepository
    {
        public StockTransactionRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }
        public override async Task<IEnumerable<StockTransaction>> All()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(StockTransactionRepository));

                throw;
            }
        }
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0;
                result.UpdatedDate = DateTime.UtcNow;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(StockTransactionRepository));
                throw;
            }
        }
        public override async Task<bool> Update(StockTransaction stockTransaction)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == stockTransaction.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.ProductId = stockTransaction.ProductId;
                result.Status = stockTransaction.Status;                
                result.Product = stockTransaction.Product;
                result.Quantity = stockTransaction.Quantity;
                result.TransactionDate = DateTime.UtcNow;
                result.TransactionType = stockTransaction.TransactionType;  

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(StockTransactionRepository));

                throw;
            }
        }

        public async Task<IEnumerable<StockTransaction>> GetStockTransactionsByTypeAsync(StockTransactionType stockTransactionType)
        {
            try
            {
                return await _dbSet.Where(x => x.TransactionType == stockTransactionType)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();                

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetStockTransactionsByTypeAsync function error", typeof(StockTransactionRepository));

                throw;
            }
        }
    }
}
