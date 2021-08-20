using Ecommerce.WebApi.Shared.Database.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Application.Search
{
    public class SearchCategoryHandler : IRequestHandler<SearchCategoryRequest, SearchCategoryResponse>
    {
        private DatabaseContext _database;

        public SearchCategoryHandler(DatabaseContext databaseContext)
        {
            _database = databaseContext;
        }

        public async Task<SearchCategoryResponse> Handle(SearchCategoryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _database
                .Categories
                .Where(category => string.IsNullOrEmpty(request.Name) || category.Name.Equals(request.Name))
                .ToListAsync();

            return new SearchCategoryResponse { Categories = categories };
        }
    }
}
