using InventoryTracking.DataService.Data;
using InventoryTracking.DataService.Repositories.Interfaces;
using InventoryTracking.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryTracking.DataService.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public override async Task<IEnumerable<Product>> All()
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
                _logger.LogError(ex, "{Repo} All function error",typeof(ProductRepository));

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
                _logger.LogError(ex, "{Repo} Delete function error", typeof(ProductRepository));
                throw;
            }
        }
        public override async Task<bool> Update(Product product)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == product.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.Name = product.Name;
                result.Description = product.Description;
                result.MinimumStockLevel = product.MinimumStockLevel;
                result.StockTransactions = product.StockTransactions;                

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(ProductRepository));

                throw;
            }
        }
    }
}
