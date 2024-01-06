using AutoMapper;
using InventoryTracking.DataService.Repositories.Interfaces;
using InventoryTracking.Entities.Dtos.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockTransactionConroller : BaseController
    {
        public StockTransactionConroller(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{stockTransactionId:guid}")]
        public async Task<IActionResult> GetStockTransaction(Guid id)
        {
            var stockTransaction = await _unitOfWork.StockTransactions.GetById(id);

            if (stockTransaction == null)
                return NotFound("Stock not found");

            var result = _mapper.Map<StockTransactionResponse>(stockTransaction);

            return Ok(result);
        }
        
    }
}
