using AutoMapper;
using InventoryTracking.Entities.DbSet;
using InventoryTracking.Entities.Dtos.Requests;
using InventoryTracking.Entities.Dtos.Responses;

namespace InventoryTracking.Api.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<StockTransaction, StockTransactionResponse>()
                .ForMember(
                dest => dest.Product,
                opt => opt.MapFrom(src => src.Product))
                
                ;
        }

        }
    }
