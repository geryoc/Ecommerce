using System.Collections.Generic;

namespace Ecommerce.WebApi.Services.Category.Application.Search
{
    public class SearchCategoryResponse
    {
        public IEnumerable<Domain.Category> Categories { get; set; }
    }
}
