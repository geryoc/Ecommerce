using MediatR;

namespace Ecommerce.WebApi.Services.Category.Application.Search
{
    public class SearchCategoryRequest : IRequest<SearchCategoryResponse>
    {
        public string Name { get; set; }
    }
}
