using Ecommerce.WebApi.Shared.Web.Requests;
using System.Collections.Generic;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class SearchProductModel : PageRequestModel
    {
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public IEnumerable<ProductOrderBy> OrderBy { get; set; } = new List<ProductOrderBy>();
    }

    public enum ProductOrderBy
    {
        Created = 0,
        CreatedDescending = 1,
        Name = 2,
        NameDescending = 3,
        Price = 4,
        PriceDescending = 5,
        Category = 6,
        CategoryDescending = 7
    }
}
