using Ecommerce.WebApi.Shared.Database.Context;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.WebApi.Services.Category.Application.Create
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, CreateCategoryResponse>
    {
        private DatabaseContext _database;

        public CreateCategoryHandler(DatabaseContext database)
        {
            _database = database;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            var category = request.Adapt<Domain.Category>();
            _database.Categories.Add(category);
            await _database.SaveChangesAsync();
            return new CreateCategoryResponse { Category = category };
        }
    }
}
