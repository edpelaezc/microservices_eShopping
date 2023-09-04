using AutoMapper;

namespace Catalog.Application.Mappers;

public static class CatalogMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(config =>
        {
            config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            config.AddProfile<ProductMappingProfile>();
        });

        var mapper = config.CreateMapper();

        return mapper;
    });

    public static IMapper mapper => Lazy.Value;
}