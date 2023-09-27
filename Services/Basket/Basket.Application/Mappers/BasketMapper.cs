using AutoMapper;

namespace Basket.Application.Mappers;

public static class BasketMapper
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(config =>
        {
            config.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod.IsAssembly;
            config.AddProfile<BasketMappingProfile>();
        });

        var lazyMapper = config.CreateMapper();

        return lazyMapper;
    });

    public static IMapper Mapper => Lazy.Value;
}