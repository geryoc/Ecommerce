using Ecommerce.WebApi.Shared.Web.Responses;
using System.Collections.Generic;

namespace Ecommerce.WebApi.Services.Product.Models
{
    public class ProductPageModel : PageResponseModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
