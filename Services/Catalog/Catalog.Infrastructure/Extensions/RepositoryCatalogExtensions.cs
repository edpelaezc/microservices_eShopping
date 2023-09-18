using Catalog.Core.Entities;
using Catalog.Core.RequestFeatures;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Dynamic.Core;

namespace Catalog.Infrastructure.Extensions;

public static class RepositoryCatalogExtensions
{
   public static IFindFluent<Product, Product> Filter(this IMongoCollection<Product> products, ProductParameters parameters)
   {
      var builder = Builders<Product>.Filter;
      var filter = builder.Empty;
      
      if (!string.IsNullOrEmpty(parameters.SearchTerm))
      {
         var searchFilter = builder.Regex(p => p.Name, new BsonRegularExpression(parameters.SearchTerm));
         filter &= searchFilter;
      }

      if (!string.IsNullOrEmpty(parameters.BrandId))
      {
         var brandFilter = builder.Eq(p => p.Brands!.Id, parameters.BrandId);
         filter &= brandFilter;
      }
      
      if(!string.IsNullOrEmpty(parameters.TypeId))
      {
         var typeFilter = builder.Eq(p => p.Types.Id, parameters.TypeId);
         filter &= typeFilter;
      }

      return products.Find(filter);
   }

   public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
   {
      if (string.IsNullOrWhiteSpace(orderByQueryString))
         return products.OrderBy(e => e.Name);

      var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

      if (string.IsNullOrWhiteSpace(orderQuery))
         return products.OrderBy(p => p.Name);

      return products.OrderBy(orderQuery);
   }
}