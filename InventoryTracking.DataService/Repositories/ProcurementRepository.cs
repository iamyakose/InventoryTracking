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
    public class ProcurementRepository : GenericRepository<Procurement>, IProcurementRepository
    {
        public ProcurementRepository(AppDbContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public override async Task<IEnumerable<Procurement>> All()
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
                _logger.LogError(ex, "{Repo} All function error", typeof(ProcurementRepository));

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
        public override async Task<bool> Update(Procurement procurement)
        {
            try
            {
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == procurement.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = procurement.UpdatedDate;
                result.IsSuggestion = false;
                result.Product = procurement.Product;
                result.PurchaseDate = procurement.PurchaseDate;


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(ProductRepository));

                throw;
            }
        }       

        public async Task<Procurement?> GetProductProcurementAsync(Guid productId)
        {
            try
            {
                var procurement = await _dbSet.FirstOrDefaultAsync(x => x.Product.Id == productId);

                return procurement ?? LogAndReturnNull("No procurement found", productId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetProductProcurementAsync function error", typeof(ProcurementRepository));
                throw;
            }
        }
        private Procurement? LogAndReturnNull(string message, Guid productId)
        {
            _logger.LogWarning($"{message} for productId: {productId}");
            return null;
        }


    }
}
