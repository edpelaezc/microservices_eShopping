using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core.Entities;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductBrand, BrandDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<ProductType, TypeDto>().ReverseMap();
        CreateMap<Product, ProductForCreationDto>().ReverseMap();
    }
}