using AutoMapper;
using InventoryTracking.DataService.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryTracking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcurementController : BaseController
    {
        public ProcurementController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
