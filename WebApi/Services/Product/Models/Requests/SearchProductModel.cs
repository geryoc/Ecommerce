using Ecommerce.WebApi.Shared.Web.Requests;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class SearchProductModel : PageRequestModel
    {
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public SearchProductOrderBy? OrderBy { get; set; }
        public SearchProductOrderBy? OrderByDescending { get; set; }
    }

    public enum SearchProductOrderBy
    {
        Created = 0,
        Name = 1,
        Price = 2,
        CategoryId = 3
    }
}
