using AutoMapper;
using Poq.Application.DTOs;
using Poq.Application.Response;

namespace Poq.Application.Common.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<GetProductsResponse, ProductDto>()
                .ForMember(x => x.Products, opt => opt.MapFrom(p => p.Products))
                .ForMember(x => x.MostCommonWords, opt => opt.Ignore())
                .ForMember(x => x.MinPrice, opt => opt.Ignore())
                .ForMember(x => x.MaxPrice, opt => opt.Ignore());

        }


    }
}

