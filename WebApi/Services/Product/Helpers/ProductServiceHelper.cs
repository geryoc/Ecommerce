using Ecommerce.WebApi.Services.Product.Models;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.WebApi.Services.Product.Helpers
{
    public static class ProductServiceHelper
    {
        public static IQueryable<Entities.Product> ProductsOrderBy(
            this IQueryable<Entities.Product> productsQuery, IEnumerable<ProductOrderBy> orderByList)
        {
            foreach (var orderBy in orderByList)
            {
                switch (orderBy)
                {
                    case ProductOrderBy.Created:
                        productsQuery = productsQuery.OrderBy(p => p.Created);
                        break;
                    case ProductOrderBy.CreatedDescending:
                        productsQuery = productsQuery.OrderByDescending(p => p.Created);
                        break;
                    case ProductOrderBy.Name:
                        productsQuery = productsQuery.OrderBy(p => p.Name);
                        break;
                    case ProductOrderBy.NameDescending:
                        productsQuery = productsQuery.OrderByDescending(p => p.Name);
                        break;
                    case ProductOrderBy.Price:
                        productsQuery = productsQuery.OrderBy(p => p.Price);
                        break;
                    case ProductOrderBy.PriceDescending:
                        productsQuery = productsQuery.OrderByDescending(p => p.Price);
                        break;
                    case ProductOrderBy.Category:
                        productsQuery = productsQuery.OrderBy(p => p.CategoryId);
                        break;
                    case ProductOrderBy.CategoryDescending:
                        productsQuery = productsQuery.OrderByDescending(p => p.CategoryId);
                        break;
                    default:
                        break;
                }
            }

            return productsQuery;
        }
    }
}
