using AutoMapper;
using InventoryTracking.Entities.DbSet;
using InventoryTracking.Entities.Dtos.Requests;

namespace InventoryTracking.Api.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateStockTransactionRequest, StockTransaction>()
                .ForMember(           
                
                dest => dest.Product,
                opt => opt.MapFrom(src => src.Product))
                .ForMember(
                    dest => dest.Status,
                    opt =>  opt.MapFrom(src=>1))
                .ForMember(
                    dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember( 
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateStockTransactionRequest, StockTransaction>()
                .ForMember(

                dest => dest.Product,
                opt => opt.MapFrom(src => src.Product))
                .ForMember(
                    dest => dest.Status,
                    opt => opt.MapFrom(src => 1))
                .ForMember(
                    dest => dest.AddedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(
                    dest => dest.UpdatedDate,
                    opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
