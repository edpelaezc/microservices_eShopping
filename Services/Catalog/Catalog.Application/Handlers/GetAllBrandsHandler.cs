using AutoMapper;
using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers;

public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandDto>>
{
    private readonly IBrandRepository _repository;

    public GetAllBrandsHandler(IBrandRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IList<BrandDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
    {
        var brands = await _repository.GetAllBrands();
        var response = 
            CatalogMapper.mapper.
            Map<IList<ProductBrand>, IList<BrandDto>>(brands.ToList());
        return response;
    }
}