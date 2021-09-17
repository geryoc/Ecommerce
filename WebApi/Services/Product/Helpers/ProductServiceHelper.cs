using Ecommerce.WebApi.Services.Product.Models;
using Ecommerce.WebApi.Shared.Helpers;
using System.Linq;

namespace Ecommerce.WebApi.Services.Product.Helpers
{
    public static class ProductServiceHelper
    {
        public static IQueryable<Entities.Product> ProductsOrderBy(this IQueryable<Entities.Product> productsQuery,
            SearchProductOrderBy? orderBy, SearchProductOrderBy? orderByDescending)
        {
            if (orderBy.HasValue)
            {
                productsQuery = productsQuery.OrderBy(orderBy.ToString());
            }
            else if (orderByDescending.HasValue)
            {
                productsQuery = productsQuery.OrderByDescending(orderByDescending.ToString());
            }
            else
            {
                productsQuery = productsQuery.OrderBy(SearchProductOrderBy.Created.ToString());
            }

            return productsQuery;
        }
    }
}
